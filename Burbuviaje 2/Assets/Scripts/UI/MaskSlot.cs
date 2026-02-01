using UnityEngine;
using UnityEngine.UI;

public class MaskSlot : MonoBehaviour
{
    public Vector2 slotKey;
    public Image slotBg, slotIcon;

    private bool _isSelected;

    public void HighlightSlot(bool isEquipped)
    {
        slotBg.color = isEquipped ? Color.yellow : Color.white;
    }
    public void LoadSlotInfo(MaskData maskData)
    {
        slotIcon.enabled = true;
        slotIcon.sprite = maskData.itemVisual;
    }
}
