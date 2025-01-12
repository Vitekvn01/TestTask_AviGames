using System;
using System.Collections.Generic;
using UnityEngine;

public class RopeController : MonoBehaviour, IRopeController
{

    private List<Rope> Ropes = new List<Rope>();

    private IGameManager _gameManager;

    public event Action OnCheckIntersectionEvent;

    private void Start()
    {
        _gameManager = ServiceLocator.GetService<IGameManager>();
        CheckRopeIntersection();
    }
    public void AddRope(Rope rope)
    {
        Ropes.Add(rope);
    }

    public void CheckRopeIntersection()
    {
        OnCheckIntersectionEvent.Invoke();

        if (CheckRopesIntersection())
        {
            _gameManager.Win();
            Debug.Log("Win");
        }
    }

    private bool CheckRopesIntersection()
    {
        foreach (Rope rope in Ropes)
        {
            if (rope.IsIntersection == true)
            {
                return false;
            }
        }

        return true;
    }
}
