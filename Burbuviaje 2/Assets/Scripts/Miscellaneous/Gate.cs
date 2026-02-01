using Unity.VisualScripting;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public MaskChecker checker;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mask"))
        {
            maskType maskInUse = collision.GetComponent<MaskSelector>().currentMask.IsUnityNull() ? maskType.None : collision.GetComponent<MaskSelector>().currentMask.maskType;
            checker.CheckMask(maskInUse);
        }
    }
}
