using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public void PHTurn(Vector2 direction)
    {
        if(direction.x < 0) { transform.rotation = Quaternion.Euler(Vector3.forward * 90); }
        if(direction.x > 0) { transform.rotation = Quaternion.Euler(Vector3.forward * -90); }
        if(direction.y < 0) { transform.rotation = Quaternion.Euler(Vector3.forward * 180); }
        if(direction.y > 0) { transform.rotation = Quaternion.Euler(Vector3.forward * 0); }
    }
}
