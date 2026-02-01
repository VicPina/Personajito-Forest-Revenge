using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInteractor interactor;
    public PlayerAnimator playerAnimator;
    public MaskSelector maskSelector;

    public float movementSpeed = 1.0f;

    private Rigidbody2D _rigidbody;

    private Vector2 _movementInput;

    public void OnPlayerMovement(InputAction.CallbackContext context)
    {
        _movementInput = context.ReadValue<Vector2>();
        if (context.performed)
        {
            playerAnimator.PHTurn(context.ReadValue<Vector2>());
        }
        else
        {
            playerAnimator.PHTurn(Vector2.zero);
        }
    }
    public void OnPlayerInteraction(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            interactor.InteractWithObject();
        }
    }
    public void OnMaskChange(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            maskSelector.ChooseMask(context.ReadValue<Vector2>());
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
        _rigidbody.linearVelocity = _movementInput * movementSpeed;
    }
}
