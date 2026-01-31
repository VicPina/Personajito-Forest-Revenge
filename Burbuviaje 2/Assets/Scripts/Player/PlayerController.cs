using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInteractor interactor;
    public PlayerAnimator playerAnimator;

    private Rigidbody2D _rigidbody;

    private Vector2 _movementInput;

    public void OnPlayerMovement(InputAction.CallbackContext context)
    {
        _movementInput = context.ReadValue<Vector2>();
    }
    public void OnPlayerInteraction(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            interactor.InteractWithObject();
        }
    }
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        MovePlayer();
    }
    private void MovePlayer()
    {
        if (_movementInput == Vector2.zero)
        {
            _rigidbody.linearVelocity = Vector2.zero;
            return;
        }
        _rigidbody.linearVelocity = _movementInput;

    }
}
