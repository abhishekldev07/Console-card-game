using System;
using System.IO;


namespace Console_Based_Card_Game
{
    // Handles writing game activity to a text file
    public class GameLog
    {
        private int lastLoggedRound;
        private string fileName;


        // Log file is created in Documents folder for easy access by user
        public GameLog()
        {
            string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CSharpGameLogs");
            Directory.CreateDirectory(folder);

            fileName = Path.Combine(folder, $"CardGameLog {DateTime.Now:yy-MM-dd_HH-mm-ss}.txt");
            File.Create(fileName).Close();
            File.WriteAllText(fileName, "===========================================\n\t       G A M E   L O G\n===========================================");
        }
        // Writes a message to the log file
        public void Message(string message)
        {
            File.AppendAllText(fileName, $"{message}");
        }
        public void PlayerSwapped(string name, int card) 
        {
            Message($"\n{DateTime.Now:hh:mm:ss tt}  {name} swapped the card '{card}'.\n");

        }
        public void PlayerStayed(string name) 
        {
            Message($"\n{DateTime.Now:hh:mm:ss tt}  {name} stayed with the same cards.\n");
        }

        // Tracks game progress round-by-round for debugging and record keeping
        public void CurrentCards(string name, int card1, int card2, bool IsGameOver, int RoundCount)
        {
            if (IsGameOver ==false && RoundCount!= this.lastLoggedRound)
            {
                Message($"\n================ Round {RoundCount} ==================\n");
            }
            else if (IsGameOver== true && RoundCount != this.lastLoggedRound)
            {
                Message("\n========== F I N A L   C A R D S ==========\n");
            }
            Message($"\n{name} has {card1}, {card2}\n");
            this.lastLoggedRound = RoundCount;
        }

        public void Result(string name) 
        {
            Message($"\n{name} won the game.\n");
            Message("\n===========================================\n");

        }
        public void Result()
        { 
            Message($"\nTie game.\n");
            Message("\n===========================================\n");
        }
        public void ShowLog()
        {   
            using (StreamReader Log = new StreamReader(fileName)) 
            {
                string line;
                while ((line = Log.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}