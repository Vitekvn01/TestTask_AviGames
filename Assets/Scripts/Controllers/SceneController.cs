using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour, ISceneManager
{
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadSceneTimer(int sceneIndex, float time)
    {
        StartCoroutine(TransitionToScene(sceneIndex, time));
    }

    private IEnumerator TransitionToScene(int index, float delay)
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(index);
    }
}
