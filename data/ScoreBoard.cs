using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TennisGame.data
{
    public class ScoreBoard
    {
        public int ScorePlayer1 = 5;
        public int ScorePlayer2 = 4;
        public bool Finished = false;
        public string Winner = "";

        public ScoreBoard() { }

        public string Score()
        {
            string ScoreText1 = TranslateScore(ScorePlayer1);
            string ScoreText2 = TranslateScore(ScorePlayer2);
            return $"Player 1: {ScoreText1}       Player 2: {ScoreText2}\n { Advantage(ScorePlayer1, ScorePlayer2) }         {Advantage(ScorePlayer2, ScorePlayer1)}  \n { Winner }";
        }

        private string TranslateScore(int score)
        {
            return score == 0 ? "Love" : score == 1 ? "15" : score == 2 ? "30" : "40";
        }

        public void CheckResults()
        {
            if (!Finished) 
            { 
                if (isWinner(ScorePlayer1, ScorePlayer2) ) 
                {
                    Winner = "Player 1";
                    Finished = true;
                }
                else if (isWinner(ScorePlayer2, ScorePlayer1))
                {
                    Winner = "Player 2";
                    Finished = true;
                }
            }
           
        }


        //Checks if the first int paramater is in a winning position
        private bool isWinner(int winner, int competition)
        {
            if (winner >= competition + 2 && winner >= 4)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private string Advantage(int score1, int score2)
        {
            if (score1 == score2 + 1 && score1 >= 4 && score2 >= 4)
            {
                return "Advantage";
            }
            return "";
        }

        public void AddScore()
        {
            int selectedPlayer = ShowMenu.Menu("Which Player scored?", new[] { "Player 1", "Player 2" });

            switch (selectedPlayer)
            {
                case 0:
                    ScorePlayer1++;
                    break;
                case 1:
                    ScorePlayer2++;
                    break;

            }
        }
    }
}
