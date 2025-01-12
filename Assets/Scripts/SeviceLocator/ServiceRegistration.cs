using UnityEngine;

public class ServiceRegistration : MonoBehaviour
{
    [SerializeField] private RopeController _ropeController;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private SceneController _sceneController;
    [SerializeField] private SoundController _soundController;
    private void Awake()
    {
        ServiceLocator.RegisterService<IRopeController, RopeController>(_ropeController);
        ServiceLocator.RegisterService<IGameManager, GameManager>(_gameManager);
        ServiceLocator.RegisterService<IScoreManager, ScoreManager>(_scoreManager);
        ServiceLocator.RegisterService<ISceneManager, SceneController>(_sceneController);
        ServiceLocator.RegisterService<ISound, SoundController>(_soundController);
    }

    private void OnDestroy()
    {
        ServiceLocator.ClearService();
    }
}
