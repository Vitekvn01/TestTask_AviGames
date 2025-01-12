using System;
using UnityEngine;

public class GameManager : MonoBehaviour, IGameManager
{
    [SerializeField] private int _scoreAward;

    public event Action OnWinEvent;

    public void Win()
    {
        OnWinEvent?.Invoke();
    }

    public int GetScoreAward()
    {
        return _scoreAward;
    }

}
