using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinPanelView : MonoBehaviour
{
    [SerializeField] private Button WinButton;

    [SerializeField] private TextMeshProUGUI ScoreAwardText;

    [SerializeField] private Image _imageTrueDecision;

    private IGameManager _gameManager;
    private IScoreManager _scoreManager;
    private ISceneManager _sceneManager;

    private bool _isButtonHold = false;

    private void Start()
    {
        _gameManager = ServiceLocator.GetService<IGameManager>();
        ScoreAwardText.text = "Score:+" + _gameManager.GetScoreAward().ToString();

        _scoreManager = ServiceLocator.GetService<IScoreManager>();

        _sceneManager = ServiceLocator.GetService<ISceneManager>();

        SubButtonHold();
    }

    private void SubButtonHold()
    {
        WinButton.onClick.AddListener(WinHold);
    }

    private void WinHold()
    {
        if (_isButtonHold == false)
        {
            _scoreManager.AddScore(_gameManager.GetScoreAward());
            _sceneManager.LoadSceneTimer(1, 3f);
            _isButtonHold = true;
        }

    }




}
