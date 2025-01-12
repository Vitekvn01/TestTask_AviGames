using UnityEditor;
using UnityEngine;

public class KnotView : MonoBehaviour
{
    [SerializeField] private GameObject _effectSelect;

    [SerializeField] private KnotHandler _handler;

    private void Start()
    {
        SubHandlerEvent();
    }

    private void SubHandlerEvent()
    {
        _handler.OnPointnerEnterEvent += ActiveEffect;
        _handler.OnPointnerExitEvent += DisactiveEffect;
    }

    private void ActiveEffect()
    {
        _effectSelect.SetActive(true);
    }

    private void DisactiveEffect()
    {
        _effectSelect.SetActive(false);
    }

    private void OnDestroy()
    {
        UnsubHandlerEvent();
    }

    private void UnsubHandlerEvent()
    {
        _handler.OnPointnerEnterEvent -= ActiveEffect;
        _handler.OnPointnerExitEvent -= DisactiveEffect;
    }

    void OnDrawGizmos()
    {

        string labelText = gameObject.name.ToString();

        Handles.Label(transform.position, labelText);
    }
}
