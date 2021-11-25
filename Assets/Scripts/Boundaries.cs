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
    }

    private void CheckBorders()
    {
        Vector3 pos = transform.position;

        if (pos.x < -10.5f - _objectWidth)
        {
            pos.x = 10.5f;
        }

        if (pos.x > 10.5f + _objectWidth)
        {
            pos.x = -10.5f;
        }

        if (pos.y < -5.8f - _objectHeight)
        {
            pos.y = 5.8f;
        }

        if (pos.y > 5.8f + _objectHeight)
        {
            pos.y = -5.8f;
        }

        transform.position = pos;
    }
}