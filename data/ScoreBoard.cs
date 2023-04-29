using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TennisGame.data
{
    public class ScoreBoard
    {
        public int ScorePlayer1 { get; set; } = 0;
        public int ScorePlayer2 { get; set; } = 0;
        public bool Finished { get; set; } = false;
        
        public ScoreBoard() { }

        public string Score()
        {
            return ScorePlayer1 + " " + ScorePlayer2; 
        }

        public void AddScore()
        {
            int selectedPlayer = ShowMenu.Menu("Which Player scored?", new[] {"Player 1", "Player 2"});

            switch (selectedPlayer)
            {
                case 0:
                    {
                        ScorePlayer1++;
                        break;
                    }
                case 1: 
                    { 
                    ScorePlayer2++; break;
                    }
            }
        }
    }
}
