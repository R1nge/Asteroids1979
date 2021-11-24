using System;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Camera _camera;
    private Vector2 _screenBounds;
    private float _objectWidth;
    private float _objectHeight;

    private void Awake()
    {
        _camera = FindObjectOfType<Camera>();
    }

    private void Start()
    {
        _screenBounds =
            _camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, _camera.transform.position.z));
        _objectWidth = spriteRenderer.bounds.extents.x * 2;
        _objectHeight = spriteRenderer.bounds.extents.y * 2;
    }

    private void LateUpdate()
    {
        var viewPos = transform.position;
        
        if (viewPos.x < _screenBounds.x + _objectWidth)
        {
            viewPos.x = -_screenBounds.x - _objectWidth;
        }

        if (viewPos.x > -_screenBounds.x - _objectWidth)
        {
            viewPos.x = _screenBounds.x + _objectWidth;
        }

        if (viewPos.y < _screenBounds.y + _objectHeight)
        {
            viewPos.y = -_screenBounds.y - _objectHeight;
        }

        if (viewPos.y > -_screenBounds.y - _objectHeight)
        {
            viewPos.y = _screenBounds.y + _objectHeight;
        }

        transform.position = viewPos;
    }
}