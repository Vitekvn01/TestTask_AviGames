using System;

public interface IScoreManager
{
    public event Action<int> OnScoreUpdateEvent;
    public void AddScore(int count);

    public void RemoveScore(int count);

    public int GetCurrentScore();
}
