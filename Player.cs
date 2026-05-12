using Console_Based_Card_Game;
// Holds player data + logic
public class Player
{
    public const int FirstIndex = 0;
    public const int SecondIndex = 1;
    const int MinCard = 1;
    const int MaxCard = 8;
    public static Random random = new Random();
    // Stores two cards for each player
    private int[] card = new int[2];
    private int DifferenceScore;
    public string Name { get; set; }

    // Initialize player with random cards(1-8)
    public Player()
    {
        this.card[0] = random.Next(MinCard, MaxCard + 1);
        this.card[1] = random.Next(MinCard, MaxCard + 1);
        this.DifferenceScore = Math.Abs(card[0] - card[1]);
    }
    public int GetCard(int index)
    {
        return card[index];
    }

    public void SwapCard(int index)
    { 
        this.card[index] = random.Next(MinCard, MaxCard + 1);
        SetDifference();
    }

    public int GetDifference()
    {
        
        return DifferenceScore;
    }
    // Calculates difference between two cards (score logic)
    public void SetDifference()
    {
        this.DifferenceScore = Math.Abs(card[0] - card[1]);
    }
    // Default behavior is to stay; specific player types (like Bot)
    // override this to implement their own strategy
    public virtual MoveType DecideMove()
    {
        return MoveType.Stick;
    }
}
// Represents human player

public class User : Player
{

}
// Bot class represents computer-controlled player
public class Bot : Player
{
    public Bot()
    {
        this.Name = "Opponent";
    }
    // AI logic to decide best move
    // Bot uses simple strategy:
    // - Keeps cards when difference is low to avoid unnecessary risk
    // - Swaps higher-value card to try minimizing the difference
    // - Uses card values as a secondary factor to improve chances in tie conditions
    public override MoveType DecideMove()
    {

        if((GetDifference() < 3 && (GetCard(FirstIndex) <= 5 && GetCard(SecondIndex) <= 5))|| GetDifference() == 0)
        {
            //Stick();
           return MoveType.Stick;
        }
        else
        {
            if (GetCard(FirstIndex) > 5 && GetCard(SecondIndex) <= 5)
            {
                return MoveType.SwapFirst;
            }
            else if ( GetCard(SecondIndex) > 5 &&  GetCard(FirstIndex) <= 5)
            {
                return MoveType.SwapSecond;
            }
            else
            {
                if (GetCard(FirstIndex) > GetCard(SecondIndex))
                {
                    return MoveType.SwapFirst;
                }
                else
                {
                    return MoveType.SwapSecond;

                }
            }
        }
    }
}