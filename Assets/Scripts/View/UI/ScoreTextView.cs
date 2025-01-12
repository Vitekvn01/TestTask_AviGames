using TMPro;
using UnityEngine;

public class ScoreTextView : MonoBehaviour
{
    private TextMeshProUGUI _scoreText;

    private IScoreManager _scoreManager;
    private void Start()
    {
        _scoreText = gameObject.GetComponent<TextMeshProUGUI>();

        _scoreManager = ServiceLocator.GetService<IScoreManager>();
        _scoreText.text = "Score:" + _scoreManager.GetCurrentScore().ToString();
        _scoreManager.OnScoreUpdateEvent += TextUpdate;

    }

    // Update is called once per frame
    private void TextUpdate(int count)
    {
        _scoreText.text = "Score:" + count;
    }
}
