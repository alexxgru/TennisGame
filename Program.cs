using TennisGame.data;

Console.WriteLine("Hello, World!");

ScoreBoard scoreBoard = new ScoreBoard(); 


while (!scoreBoard.Finished)
{
    Display.RefreshDisplay(scoreBoard);

    scoreBoard.AddScore();



}