using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public MaskSlot[] maskSlot = new MaskSlot[4];

    private Dictionary<MaskData, MaskSlot> _maskRelation = new Dictionary<MaskData, MaskSlot>();
    private MaskData _chosenMask;

    public void MaskAdditionFeedback(MaskData maskToAdd)
    {
        foreach(MaskSlot slot in maskSlot)
        {
            if (!_maskRelation.ContainsValue(slot))
            {
                _maskRelation.Add(maskToAdd, slot);

                slot.LoadSlotInfo(maskToAdd);

                break;
            }
        }
    }
    public void MaskSelectionFeedback(MaskData maskToChoose)
    {
        if (!_chosenMask.IsUnityNull())
        {
            _maskRelation[_chosenMask].HighlightSlot(false);
        }
        if (!maskToChoose.IsUnityNull())
        {

            _chosenMask = maskToChoose;

            _maskRelation[maskToChoose].HighlightSlot(true);
        }
    }
}
