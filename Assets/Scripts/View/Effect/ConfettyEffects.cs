using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettyEffects : MonoBehaviour
{
   [SerializeField] private GameObject[] gameObjects;

    private IGameManager _gameManager;

    private void Start()
    {
        _gameManager = ServiceLocator.GetService<IGameManager>();
        _gameManager.OnWinEvent += Activated;
    }

    private void Activated()
    {
        foreach (GameObject gameObject in gameObjects)
        {
            gameObject.SetActive(true);
        }
    }
}
