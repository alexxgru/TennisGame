using TennisGame.data;

Console.WriteLine("Hello, World!");

ScoreBoard scoreBoard = new ScoreBoard(); 


while (!scoreBoard.Finished || true)
{
    Display.RefreshDisplay(scoreBoard);

    scoreBoard.CheckResults();

    if (!scoreBoard.Finished || true)
    {
        scoreBoard.AddScore();
    }



}