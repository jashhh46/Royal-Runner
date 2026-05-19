using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody RB;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] Vector2 clamp;
    Vector2 move;
    private void Awake()
    {
        RB = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        HandleMovement();
    }
    public void Move(InputAction.CallbackContext context)
    { 
        move = context.ReadValue<Vector2>();
        Debug.Log(move);
    }
    public void HandleMovement()
    { 
        Vector3 currentPosition = RB.position;
        Vector3 moveDirection = new Vector3(move.x, 0f, move.y);
        Vector3 newPosition = currentPosition + moveDirection * (moveSpeed * Time.fixedDeltaTime) ;

        newPosition.x = Mathf.Clamp(newPosition.x, -clamp.x, clamp.x);
        newPosition.z = Mathf.Clamp(newPosition.z, -clamp.y, clamp.y);
        RB.MovePosition(newPosition);
    }
}
