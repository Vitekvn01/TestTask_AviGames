using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject WinPanel;

    private IGameManager _gameManager;

    private void Start()
    {
        _gameManager = ServiceLocator.GetService<IGameManager>();
        _gameManager.OnWinEvent += ActiveWinPanel;
    }

    private void ActiveWinPanel()
    {
        WinPanel.SetActive(true);
    }

    private void OnDestroy()
    {
        _gameManager.OnWinEvent -= ActiveWinPanel;
    }
}
