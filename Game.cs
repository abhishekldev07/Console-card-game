
namespace Console_Based_Card_Game
{
    // Represents possible moves a player can make
    public enum MoveType
    {
        Stick,
        SwapFirst,
        SwapSecond
    }

    //Main controller class that manages game loop, player turns and final result
    public class Game
    {
        public int RoundCount;
        private GameLog log;
        private Player human;
        private Player bot;
        private ConsoleUI UI;
        const int FirstIndex = 0;
        const int SecondIndex = 1;
        const int MaxRound = 3;
        private bool IsGameOver;

        // Main entry point of the program
        static void Main(string[] args)
        {

            Game game = new Game();
            game.StartGame();
        }

        // Starts and controls the full game flow
        public void StartGame()
        {
            // Reset game state
            IsGameOver = false;
            RoundCount = 0;

            // Initialize UI and log system
            UI = new ConsoleUI();
            log = new GameLog();
            UI.GameBanner();

            // Create players
            human = new User();
            human.Name = UI.AskName();
            bot = new Bot();

            UI.GameStartedBanner();
            // Main game loop (runs for 3 rounds)
            while (RoundCount < MaxRound)
            {
                RoundCount += 1;

                // Log current state
                log.CurrentCards(human.Name, human.GetCard(FirstIndex), human.GetCard(SecondIndex), IsGameOver, RoundCount);
                log.CurrentCards(bot.Name, bot.GetCard(FirstIndex), bot.GetCard(SecondIndex), IsGameOver, RoundCount);

                UI.ShowCards(human, bot, IsGameOver);
                PlayRound(human, bot, RoundCount);
            }
            EndGame(human, bot);
        }

        // Handles one round of gameplay (both human and bot turns)
        private void PlayRound(Player human, Player bot, int RoundCount)
        {
            UI.RoundShow(RoundCount);
            int choice;
            // User is given choice to either keep current cards or improve score by swapping
            choice = UI.Stick_or_Swap();
            
            // HUMAN TURN
            if (choice == 1)
            {
                log.PlayerStayed(human.Name);
                UI.PlayerStayed(human.Name);
            }
            else if (choice == 2)
            {
                choice = UI.WhichCard(human.GetCard(FirstIndex), human.GetCard(SecondIndex));
                int index = 0; // default index
                if (choice == 1)
                {   
                    index = FirstIndex;
                    UI.CardSwapped(human.Name, FirstIndex);
                    log.PlayerSwapped(human.Name, human.GetCard(FirstIndex));
                }
                if (choice == 2)
                {
                    index = SecondIndex;
                    UI.CardSwapped(human.Name, SecondIndex);
                    log.PlayerSwapped(human.Name, human.GetCard(SecondIndex));
                }
                human.SwapCard(index);
            }
            // BOT TURN
            // Bot only decides the move here, actual action is executed by Game
            // This separation keeps decision logic independent from game execution
            MoveType decision = bot.DecideMove();   
            if (decision == MoveType.Stick)
            {
                log.PlayerStayed(bot.Name);
                UI.PlayerStayed(bot.Name);
            }
            else if (decision == MoveType.SwapFirst)
            {
                log.PlayerSwapped(bot.Name, bot.GetCard(FirstIndex));
                UI.CardSwapped(bot.Name, FirstIndex);
                bot.SwapCard(FirstIndex);
            }
            else if (decision == MoveType.SwapSecond)
            {
                log.PlayerSwapped(bot.Name, bot.GetCard(SecondIndex));
                UI.CardSwapped(bot.Name, SecondIndex);
                bot.SwapCard(SecondIndex);
            }
        }

        // Winner is determined primarily by lowest difference between cards
        // If tied, total card value is used as a secondary condition
        private void DetermineWinner(Player human, Player bot)
        {
            if (human.GetDifference() < bot.GetDifference() ||
               (human.GetDifference() == bot.GetDifference() &&
               (human.GetCard(FirstIndex) + human.GetCard(SecondIndex)) < (bot.GetCard(FirstIndex) + bot.GetCard(SecondIndex))))
            {
                UI.Result(human.Name);
                log.Result(human.Name);
            }
            else if (human.GetDifference() > bot.GetDifference() ||
                     (human.GetDifference() == bot.GetDifference() &&
                     (human.GetCard(FirstIndex) + human.GetCard(SecondIndex)) > (bot.GetCard(FirstIndex) + bot.GetCard(SecondIndex))))
            {
                UI.Result(bot.Name);
                log.Result(bot.Name);
            }
            else
            {
                UI.Result();
                log.Result();
            }

        }
        // Final stage of game
        private void EndGame(Player human, Player bot)
        {
            IsGameOver = true;
            UI.ResultBanner();
            UI.ShowCards(human, bot, IsGameOver);
            // Log final cards
            log.CurrentCards(human.Name, human.GetCard(FirstIndex), human.GetCard(SecondIndex), IsGameOver, RoundCount);
            log.CurrentCards(bot.Name, bot.GetCard(FirstIndex), bot.GetCard(SecondIndex), IsGameOver, RoundCount);

            DetermineWinner(human, bot);
            if (UI.AskLog() == true)
            {
                log.ShowLog();
            }
            if (UI.AskAnotherMatch() == true)
            {
                StartGame();
            }
        }
    }
   
}