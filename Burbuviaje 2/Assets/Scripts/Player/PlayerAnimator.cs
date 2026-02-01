using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Vector2 _lastMoveDirection = Vector2.down;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PHTurn(Vector2 direction)
    {
        //Guardo el ultimo movimiento para saber para donde iba
        if (direction != Vector2.zero)
        {
            _lastMoveDirection = direction;
        }
        animator.SetFloat("Horizontal", _lastMoveDirection.x);
        animator.SetFloat("Vertical", _lastMoveDirection.y);
        animator.SetFloat("Velocidad", direction.magnitude);
        //sDebug.Log($"Original: {direction.magnitude}  Ultimo: {_lastMoveDirection.magnitude}");

        //if (direction.x < 0) { transform.rotation = Quaternion.Euler(Vector3.forward * 90); }
        //if(direction.x > 0) { transform.rotation = Quaternion.Euler(Vector3.forward * -90); }
        //if(direction.y < 0) { transform.rotation = Quaternion.Euler(Vector3.forward * 180); }
        //if(direction.y > 0) { transform.rotation = Quaternion.Euler(Vector3.forward * 0); }
    }
}
