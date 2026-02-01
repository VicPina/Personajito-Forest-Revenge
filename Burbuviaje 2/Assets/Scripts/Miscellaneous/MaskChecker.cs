using UnityEngine;
using UnityEngine.Events;

public class MaskChecker : MonoBehaviour
{
    public maskType maskNeeded;
    public UnityEvent onRightMask, onWrongMask;
    private void CheckMask(maskType maskEquipped)
    {
        if(maskNeeded == maskEquipped)
        {
            onRightMask.Invoke();
            return;
        }
        onWrongMask.Invoke();
    }
}
