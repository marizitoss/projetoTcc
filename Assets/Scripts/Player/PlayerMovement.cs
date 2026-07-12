using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rigidbody;
    private Vector2 movementDirection;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetMovementDirection(Vector2 direction)
    {
        movementDirection = direction;
    }

    private void FixedUpdate()
    {
        rigidbody.linearVelocity = movementDirection * moveSpeed;

    }
}
