using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private AudioSource thrustSound;
    private Rigidbody2D _rigidbody2D;

    private void Awake() => _rigidbody2D = GetComponent<Rigidbody2D>();

    private void Update() => GetInput();

    private void GetInput()
    {
        if (Input.GetKey(KeyCode.W))
            MoveForward();


        if (Input.GetKey(KeyCode.A))
            RotateLeft();
        

        if (Input.GetKey(KeyCode.D))
            RotateRight();
        
    }

    private void MoveForward()
    {
        _rigidbody2D.AddForce(transform.right * speed);
        thrustSound.Play();
    }

    private void RotateLeft() => transform.Rotate(0, 0, rotationSpeed);

    private void RotateRight() => transform.Rotate(0, 0, -rotationSpeed);
}