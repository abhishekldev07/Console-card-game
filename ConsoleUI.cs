namespace Console_Based_Card_Game
{
    // Handles all user interaction (input/output)
    public class ConsoleUI
    {
        const int FirstIndex = 0;
        const int SecondIndex = 1;
       public  void GameBanner()
        {
            Console.WriteLine("========================================\n\t    NUMBER CARD GAME\t\n========================================");
            Console.WriteLine("");
        }
        public  string AskName()
        {
            Console.Write("\n  Enter your name\n");
            Console.Write("=> ");
            return Console.ReadLine();
        }
        public  void GameStartedBanner()
        {
            Console.WriteLine("\n<======== G A M E   S T A R T E D ========>\n");
        }
        // Displays cards (hides bot cards until game ends)
        public void ShowCards(Player human, Player bot, bool IsGameOver)
        {
            Console.WriteLine($"\nYour cards: {human.GetCard(FirstIndex)}, {human.GetCard(SecondIndex)}\nScore: {human.GetDifference()}");

            if (IsGameOver ==true)
            {
                Console.WriteLine($"\nComputer cards: {bot.GetCard(FirstIndex)}, {bot.GetCard(SecondIndex)}\nScore: {bot.GetDifference()}\n");
            }
            else
            {
                Console.WriteLine("\nComputer cards: [Hidden], [Hidden]\n");
            }
        }
        public void RoundShow(int RoundCount)
        {
            Console.WriteLine("\n================ Round " + RoundCount + " ==================\n");
        }
        public int Stick_or_Swap()
        {
            Console.Write("Choose one:\n1. Stick with current cards\n2. Swap card\n");
            return choose();
        }

        public int WhichCard( int card1, int card2)
        {
            Console.WriteLine($"\nWhich card do you wanna swap?\n1. Card {card1}\n2. Card {card2}\n");
            return choose(); 
        }
        // Ensures valid user input (1 or 2)
        public int choose()
        {
            int choice;
            while (true)
            {
                try
                {
                    Console.Write("=> ");
                    choice = Convert.ToInt32(Console.ReadLine());
                    if (choice != 1 && choice != 2)
                    {
                        Console.WriteLine("Please enter a valid input (1 or 2).");
                        continue;
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("That's not a number. Enter 1 or 2.");
                }
            }
            return choice;
        }

        public void ResultBanner()
        {
            Console.WriteLine("\n============= Final Result =============\n");
        }
        public void Result(string Winner)
        {

            Console.WriteLine("\n" + Winner + " won the game.\n");
            Console.WriteLine("\n==============================================\n");
        }
        public void Result() // TIE CONDITION
        {
            Console.WriteLine("It's a tie game.\n");
            Console.WriteLine("\n==============================================\n");
        }
        public bool AskLog()
        {
            Console.WriteLine("Do you wanna see game log?\n");
            return YesNo();
        }
        public bool AskAnotherMatch()
        {
            Console.WriteLine("Do you want another match?\n");
            return YesNo();
        }
        // Ensures valid input 
        public bool YesNo()
        {
            while (true)
            {
                string choice;
                Console.Write("=> ");
                choice = Console.ReadLine();
                if (choice.ToLower() == "yes")
                {
                    return true;                
                }
                else if (choice.ToLower() == "no")
                {
                    Console.WriteLine("\n==============================================\n");
                    return false;
                }
                else
                {
                    Console.WriteLine("Please enter Yes/No");
                    continue;
                }
            }
        }

        public void PlayerStayed(string name)
        {
            Console.WriteLine($"\n{name} stayed with the same cards.\n");
        }

        public void CardSwapped(string Name, int index)
        {
            if (index == 0)
            {
                Console.WriteLine($"\n{Name} swapped the first card.");
            }
            else if (index == 1)
            {
                Console.WriteLine($"\n{Name} swapped the second card.");
            }
        }
      
    }
}
