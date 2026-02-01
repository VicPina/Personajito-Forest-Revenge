using UnityEngine;
using UnityEngine.Events;

public class MaskChecker : MonoBehaviour
{
    public maskType maskNeeded;
    public UnityEvent onRightMask, onWrongMask;
    public void CheckMask(maskType maskEquipped)
    {
        if(maskNeeded == maskEquipped)
        {
            onRightMask.Invoke();
            return;
        }
        onWrongMask.Invoke();
    }
}
