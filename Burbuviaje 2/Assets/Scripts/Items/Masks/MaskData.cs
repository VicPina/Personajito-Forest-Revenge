using UnityEngine;

public enum maskType
{
    None = 0,
    Bosque = 1,
    Pantano = 2,
    Desierto = 3,
    Medieval = 4
}

[CreateAssetMenu(fileName = "Mask", menuName = "Scriptable Objects/Interactables/Mask")]
public class MaskData : InteractableItemData
{
    public maskType maskType;
}
