using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private PolygonCollider2D _collider2D;
    private Camera _camera;
    private float _objectWidth;
    private float _objectHeight;
    private float _minX, _maxX, _minY, _maxY;

    private void Awake()
    {
        _camera = FindObjectOfType<Camera>();
        _collider2D = GetComponent<PolygonCollider2D>();
    }

    private void Start()
    {
        SetupValues();
    }

    private void LateUpdate()
    {
        CheckBorders();
    }

    private void SetupValues()
    {
        _objectWidth = _collider2D.bounds.extents.x;
        _objectHeight = _collider2D.bounds.extents.y;

        float camDistance = Vector3.Distance(transform.position, _camera.transform.position);

        Vector2 bottomCorner = _camera.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = _camera.ViewportToWorldPoint(new Vector3(1, 1, camDistance));

        _minX = bottomCorner.x + _objectWidth;
        _maxX = topCorner.x - _objectWidth;
        _minY = bottomCorner.y + _objectHeight;
        _maxY = topCorner.y - _objectHeight;
    }

    private void CheckBorders()
    {
        Vector3 pos = transform.position;

        if (pos.x < _minX) pos.x = _maxX;
        if (pos.x > _maxX) pos.x = _minX;

        if (pos.y < _minY) pos.y = _maxY;
        if (pos.y > _maxY) pos.y = _minY;

        transform.position = pos;
    }
}