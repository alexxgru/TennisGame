using TennisGame.ScoreBoard;

Console.WriteLine("Hello, World!");

bool running = true;
ScoreBoard scoreBoard = new ScoreBoard(); 


while (running)
{
    Console.WriteLine(scoreBoard.Score());

    scoreBoard.AddScore();


}