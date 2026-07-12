using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement movement;
    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movement.SetMovementDirection(context.ReadValue<Vector2>());
    }
}
