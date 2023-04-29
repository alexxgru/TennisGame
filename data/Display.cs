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
            Console.WriteLine("-----------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("         " + scoreBoard.Score());
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------");

        }

    }
}
