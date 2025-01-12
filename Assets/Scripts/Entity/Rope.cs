using UnityEditor;
using UnityEngine;

public class Rope : MonoBehaviour
{
    [SerializeField] private Sprite _greenSprite;
    [SerializeField] private Sprite _redSprite;

    private IRopeController _ropeController;

    [SerializeField] private Transform _transformAnchor1; // Первая точка крепления
    [SerializeField]private Transform _tranformAnchor2; // Вторая точка крепления

    private SpriteRenderer _spriteRenderer;

    public bool IsIntersection { get; private set; }

    void Start()
    {
        _ropeController = ServiceLocator.GetService<IRopeController>();

        _ropeController.OnCheckIntersectionEvent += CheckIntersections;
        _ropeController.AddRope(this);

        _spriteRenderer = GetComponent<SpriteRenderer>();

        CheckIntersections();
    }

    void Update()
    {
        if (_spriteRenderer != null && _transformAnchor1 != null && _tranformAnchor2 != null)
        {
            DrawPosition();
        }
    }

    private void DrawPosition()
    {
        float distance = Vector2.Distance(_transformAnchor1.position, _tranformAnchor2.position);

        Vector3 midPoint = (_transformAnchor1.position + _tranformAnchor2.position) / 2;
        transform.position = midPoint;


        Vector3 scale = transform.localScale;
        scale.x = distance / (_spriteRenderer.sprite.bounds.size.x + 0.5f);
        transform.localScale = scale;

        Vector2 direction = _tranformAnchor2.position - _transformAnchor1.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void CheckIntersections()
    {
        Vector2 direction = (_tranformAnchor2.position - _transformAnchor1.position).normalized;

        // Смещаем начало и конец линии
        Vector2 start = (Vector2)_transformAnchor1.position + direction * 0.3f;  
        Vector2 end = (Vector2)_tranformAnchor2.position - direction * 0.3f;  

        RaycastHit2D[] hits = Physics2D.LinecastAll(start, end);

        bool isIntersecting = false;

        foreach (var hit in hits)
        {
            if (hit.collider != null && hit.collider.gameObject != gameObject)
            {
                if (hit.collider.TryGetComponent(out Rope otherRope))
                {
                    isIntersecting = true;
                    break;
                }
            }
        }

        if (isIntersecting)
        {
            ChangeRedSprite();
            IsIntersection = true;
        }
        else
        {
            ChangeGreenSprite();
            IsIntersection = false;
        }
    }

    private void ChangeRedSprite()
    {
        _spriteRenderer.sprite = _redSprite;
    }

    private void ChangeGreenSprite()
    {
        _spriteRenderer.sprite = _greenSprite;
    }

    private void OnDestroy()
    {
        _ropeController.OnCheckIntersectionEvent -= CheckIntersections;
    }
    void OnDrawGizmos()
    {
        Vector2 direction = (_tranformAnchor2.position - _transformAnchor1.position).normalized;

        // Смещаем начало и конец линии
        Vector2 start = (Vector2)_transformAnchor1.position + direction * 0.3f;  // Смещаем на 1 в сторону transformAnchor1
        Vector2 end = (Vector2)_tranformAnchor2.position - direction * 0.3f;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(start, end);

        Vector3 midPoint = (start + end) / 2;

        string labelText = gameObject.name.ToString();

        Handles.Label(midPoint, labelText );
    }
}
