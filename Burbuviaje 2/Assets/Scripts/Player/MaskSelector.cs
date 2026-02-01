using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MaskSelector : MonoBehaviour
{
    public Vector2 currentMaskIndex;
    public MaskData currentMask;

    public HUD playerHUD;

    private Collider2D _maskDetectionTrigger;
    private Dictionary<Vector2, MaskData> _masks = new Dictionary<Vector2, MaskData>();
    private Vector2[] _maskKeys = new Vector2[4];
    private void Awake()
    {
        _maskDetectionTrigger = GetComponent<Collider2D>();

        FillMaskDictionary();
    }
    private void FillMaskDictionary()
    {
        _masks.Add(Vector2.zero, null);
        _masks.Add(Vector2.left, null);
        _maskKeys[0] = Vector2.left;
        _masks.Add(Vector2.up, null);
        _maskKeys[1] = Vector2.up;
        _masks.Add(Vector2.down, null);
        _maskKeys[2] = Vector2.down;
        _masks.Add(Vector2.right, null);
        _maskKeys[3] = Vector2.right;
    }
    public void AddMask(Mask newMask)
    {
        foreach(Vector2 key in _maskKeys)
        {
            if (_masks[key] == null)
            {
                _masks[key] = newMask.maskInfo;

                playerHUD.MaskAdditionFeedback(newMask.maskInfo);

                break;
            }
        }

    }
    public void ChooseMask(Vector2 newMask)
    {
        Vector2 maskToChoose = new Vector2();

        if (newMask.x < 0) { maskToChoose = Vector2.left; }
        if (newMask.y > 0) { maskToChoose = Vector2.up; }
        if (newMask.y < 0) { maskToChoose = Vector2.down; }
        if (newMask.x > 0) { maskToChoose = Vector2.right; }

        if(maskToChoose == currentMaskIndex) 
        { 
            currentMaskIndex = Vector2.zero;
            EquipMask();
            return;
        }
        currentMaskIndex = maskToChoose;

        EquipMask();
    }
    private void EquipMask()
    {
        currentMask = _masks[currentMaskIndex];

        playerHUD.MaskSelectionFeedback(currentMask);

        StartCoroutine(ResetCollider());
    }
    private IEnumerator ResetCollider()
    {
        _maskDetectionTrigger.enabled = false;
        yield return new WaitForEndOfFrame();
        _maskDetectionTrigger.enabled = true;
    }
}
