using UnityEngine;

[CreateAssetMenu]
public class ScoreData : ScriptableObject
{
    public int Score { private set; get; }

    public void AddScore(int count)
    {
        Score += count;
    }

    public void RemoveScore(int count)
    {
        Score -= count;
    }
}
