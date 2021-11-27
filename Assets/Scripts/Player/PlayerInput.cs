using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public event Action OnMoveForward;
    public event Action OnRotateLeft;
    public event Action OnRotateRight;
    public event Action OnFife;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            OnMoveForward?.Invoke();
        }

        if (Input.GetKey(KeyCode.A))
        {
            OnRotateLeft?.Invoke();
        }

        if (Input.GetKey(KeyCode.D))
        {
            OnRotateRight?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnFife?.Invoke();
        }
    }
}