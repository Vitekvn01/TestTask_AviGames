using UnityEngine;
using UnityEngine.UI;

public class SkipButtonView : MonoBehaviour
{
    [SerializeField] private Image _imageTrueDecision;

    private Button _skipButton;

    private ISceneManager _sceneManager;

    private bool _isButtonHold = false;

    void Start()
    {
        _sceneManager = ServiceLocator.GetService<ISceneManager>();

        _skipButton = GetComponent<Button>();
        _skipButton.onClick.AddListener(SkipHold);

    }

    // Update is called once per frame
    private void SkipHold()
    {
        if (_isButtonHold == false)
        {
            _sceneManager.LoadSceneTimer(1, 3f);
            _imageTrueDecision.gameObject.SetActive(true);
            _isButtonHold = true;
        }
    }
}
