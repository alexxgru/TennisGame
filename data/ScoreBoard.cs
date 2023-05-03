using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace TennisGame.data
{
    public class ScoreBoard
    {
        public int ScorePlayer1 = 0;
        public int ScorePlayer2 = 0;
        public int SetScorePlayer1 = 0;
        public int SetScorePlayer2 = 0;
        public bool Finished = false;
        public string GameWinner = "";
        public string SetWinner = "";

        public ScoreBoard() { }

        //Returnerar strängen som visas på scoreboarden
        public string Score()
        {
            string ScoreText1 = TranslateScore(ScorePlayer1);
            string ScoreText2 = TranslateScore(ScorePlayer2);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendLine($"            Player 1: {ScoreText1}            Player 2: {ScoreText2}");
            sb.AppendLine();
            sb.AppendLine($"                         {GetGameStatus(ScorePlayer1, ScorePlayer2)}");
            sb.AppendLine();

            if (GameWinner != "")
            {
                sb.AppendLine($"                    {GameWinner} wins the game!");
            }
            else
            {
                sb.AppendLine();
            }

            if (SetWinner != "")
            {
                sb.AppendLine($"               {SetWinner} wins the entire set! *fireworks*");
            }

            return sb.ToString();
        }


        //Returnerar Set-poängställningen
        public string SetScore()
        {
            return $"Set Score: {SetScorePlayer1} - {SetScorePlayer2}";
        }


        // Från gamla hederliga poäng till tennis poäng
        private string TranslateScore(int score)
        {
            return score == 0 ? "Love" : score == 1 ? "15" : score == 2 ? "30" : "40";
        }

        //Kollar om ett game är vunnet
        public void CheckResults()
        {
            if (!Finished)
            {
                string winner = GetGameWinner();
                if (winner != null)
                {
                    GameWinner = winner;
                    AddSetScore(winner);
                }
            }

            CheckSetResults();
        }

        public void ResetGame()
        {
            ScorePlayer1 = 0;
            ScorePlayer2 = 0;
            GameWinner = "";
        }

        private void AddSetScore(string winner)
        {
            if (winner == "Player 1")
            {
                SetScorePlayer1++;
            }
            else if (winner == "Player 2")
            {
                SetScorePlayer2++;
            }
        }

        private string GetGameWinner()
        {
            if (ScorePlayer1 >= ScorePlayer2 + 2 && ScorePlayer1 >= 4)
            {
                return "Player 1";
            }
            else if (ScorePlayer2 >= ScorePlayer1 + 2 && ScorePlayer2 >= 4)
            {
                return "Player 2";
            }
            else
            {
                return null;
            }
        }


        //Har valt att implementera Tie-break sets (En spelare måste ha minst 6 Game vinster och 2 mer än motståndaren)
        private void CheckSetResults()
        {
            if (SetScorePlayer1 < 6 && SetScorePlayer2 < 6)
            {
                return;
            }

            if (SetScorePlayer1 >= 6 && SetScorePlayer1 >= SetScorePlayer2 + 2)
            {
                SetWinner = "Player 1";
                Finished = true;
            }
            else if (SetScorePlayer2 >= 6 && SetScorePlayer2 >= SetScorePlayer1 + 2)
            {
                SetWinner = "Player 2";
                Finished = true;
            }

        }

        //Kollar tillståndet i matchen; deuce, advantage eller game
        private string GetGameStatus(int score1, int score2)
        {
            if (score1 == score2)
            {
                return score1 >= 3 ? "Deuce" : "";
            }
            else if (score1 > score2)
            {
                return score1 >= 4 && score1 >= score2 + 2 ? "Game" : score1 == score2 + 1 && score1 >= 4 ? "<- Advantage" : "";
            }
            else
            {
                return score2 >= 4 && score2 >= score1 + 2 ? "Game" : score2 == score1 + 1 && score2 >= 4 ? "Advantage ->" : "";
            }
        }

        //Increments a player score 
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
