using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour, IScoreManager
{
    [SerializeField] private ScoreData _scoreData; // SO для сохранения данных между сцен

    public event Action<int> OnScoreUpdateEvent;

    private void Start()
    {
        OnScoreUpdateEvent?.Invoke(_scoreData.Score);
    }
    public void AddScore(int count)
    {
        _scoreData.AddScore(count);
        OnScoreUpdateEvent?.Invoke(_scoreData.Score);
    }

    public void RemoveScore(int count)
    {
        _scoreData.RemoveScore(count);
        OnScoreUpdateEvent?.Invoke(_scoreData.Score);
    }

    public int GetCurrentScore()
    {
        return _scoreData.Score;
    }
}
