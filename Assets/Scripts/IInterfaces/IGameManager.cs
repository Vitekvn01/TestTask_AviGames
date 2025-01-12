using System;
public interface IGameManager
{
    public event Action OnWinEvent;

    public void Win();

    public int GetScoreAward();
}
