using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Vector2 _lastMoveDirection = Vector2.down;
    private Animator animator;
    private int mask;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PHTurn(Vector2 direction, MaskData maskData)
    {
        if (maskData == null)
        {
            mask = 0;
        }
        else
        {
            switch (maskData.maskType)
            {
                case maskType.None: mask = 0; break;
                case maskType.Bosque: mask = 1; break;
                case maskType.Pantano: mask = 2; break;
                case maskType.Desierto: mask = 3; break;
                case maskType.Medieval: mask = 4; break;
            }
        }
        


        //Guardo el ultimo movimiento para saber para donde iba
        if (direction != Vector2.zero)
        {
            _lastMoveDirection = direction;
        }
        animator.SetFloat("Horizontal", _lastMoveDirection.x);
        animator.SetFloat("Vertical", _lastMoveDirection.y);
        animator.SetFloat("Velocidad", direction.magnitude);
        animator.SetInteger("Mascara", mask);
        //sDebug.Log($"Original: {direction.magnitude}  Ultimo: {_lastMoveDirection.magnitude}");

        //if (direction.x < 0) { transform.rotation = Quaternion.Euler(Vector3.forward * 90); }
        //if(direction.x > 0) { transform.rotation = Quaternion.Euler(Vector3.forward * -90); }
        //if(direction.y < 0) { transform.rotation = Quaternion.Euler(Vector3.forward * 180); }
        //if(direction.y > 0) { transform.rotation = Quaternion.Euler(Vector3.forward * 0); }
    }
}
