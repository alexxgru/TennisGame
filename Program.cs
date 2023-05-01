using TennisGame.data;

ScoreBoard scoreBoard = new ScoreBoard(); 


while (!scoreBoard.Finished || true)
{
    scoreBoard.CheckResults();
     
    Display.RefreshDisplay(scoreBoard);

    if (!scoreBoard.Finished)
    {
        scoreBoard.AddScore();
    }
    else
    {
        if (Display.ReplayPrompt())
        {
            scoreBoard = new ScoreBoard();
        }
        else
        {
            break;
        }
    }



}