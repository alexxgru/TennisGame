using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisGame.data
{
    public class Display
    {
        public static void RefreshDisplay(ScoreBoard scoreBoard)
        {
            Console.Clear();
            Console.WriteLine("                       " + scoreBoard.SetScore());
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("       " + scoreBoard.Score());
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine();

            if (scoreBoard.GameWinner != "")
            {
                Thread.Sleep(1500);
                scoreBoard.ResetGame();

                if (scoreBoard.SetWinner == "")
                {
                    RefreshDisplay(scoreBoard); 
                }
            }

        }

        public static bool ReplayPrompt()
        {
            int selected = ShowMenu.Menu("Play Again", new[] { "Yes", "No" });
            return selected == 0;
        }

    }
}
