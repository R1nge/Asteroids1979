using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private AudioSource thrustSound;
    private Rigidbody2D _rigidbody2D;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerInput = FindObjectOfType<PlayerInput>();
        _playerInput.OnMoveForward += MoveForward;
        _playerInput.OnRotateLeft += RotateLeft;
        _playerInput.OnRotateRight += RotateRight;
    }

    private void MoveForward()
    {
        _rigidbody2D.AddForce(transform.right * speed);
        thrustSound.Play();
    }

    private void RotateLeft()
    {
        transform.Rotate(0, 0, rotationSpeed);
    }

    private void RotateRight()
    {
        transform.Rotate(0, 0, -rotationSpeed);
    }
}