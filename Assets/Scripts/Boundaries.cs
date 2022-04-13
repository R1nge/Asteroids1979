using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private PolygonCollider2D _collider2D;
    private float _objectWidth;
    private float _objectHeight;

    private void Awake()
    {
        _collider2D = GetComponent<PolygonCollider2D>();
        SetupValues();
    }

    private void LateUpdate()
    {
        CheckBorders();
    }

    private void SetupValues()
    {
        var bounds = _collider2D.bounds;
        _objectWidth = bounds.extents.x;
        _objectHeight = bounds.extents.y;
    }

    private void CheckBorders()
    {
        var pos = transform.position;

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