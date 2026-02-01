using UnityEngine;

public class Mask : InteractableItem
{
    public bool isEquipped, isObtained;
    public MaskData maskInfo;

    public MaskSelector player;

    public void GetMask()
    {
        player.AddMask(this);
    }
}
