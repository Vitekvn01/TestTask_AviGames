using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class KnotHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    private bool _isDragging = false;

    private IRopeController _ropeController;
    private ISound _soundControlelr;

    private Vector3 _offset;

    public event Action OnPointnerEnterEvent;
    public event Action OnPointnerExitEvent;
    public event Action OnBeginDragEvent;
    public event Action OnDragEvent;
    public event Action OnEndDragEvent;

    private void Start()
    {
        _ropeController = ServiceLocator.GetService<IRopeController>();
        _soundControlelr = ServiceLocator.GetService<ISound>();

        OnEndDragEvent += _ropeController.CheckRopeIntersection;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnPointnerEnterEvent?.Invoke(); 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnPointnerExitEvent?.Invoke();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        _soundControlelr.PlayRope();
        OnBeginDragEvent?.Invoke();
        _offset = transform.position - Camera.main.ScreenToWorldPoint(eventData.position);
        _isDragging = true;

        Debug.Log("Начало перетаскивания");
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (_isDragging)
        {
            OnDragEvent?.Invoke();

            Vector3 newPosition = Camera.main.ScreenToWorldPoint(eventData.position) + _offset;
            newPosition.z = 0f; 
            transform.position = newPosition;
            Debug.Log("Перетаскивание");
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        _soundControlelr.StopRope();
        OnEndDragEvent?.Invoke();
        _isDragging = false;
    }

    private void OnDestroy()
    {
        OnEndDragEvent -= _ropeController.CheckRopeIntersection;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _soundControlelr.PlayClick();
    }
}
