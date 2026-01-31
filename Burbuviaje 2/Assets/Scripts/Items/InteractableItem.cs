using UnityEngine;
using UnityEngine.Events;

public class InteractableItem : MonoBehaviour
{
    [Header("Item Information")]
    public InteractableItemData itemData;
    [Header("Item Functionality")]
    public SpriteRenderer spriteRenderer;
    public UnityEvent onInteraction;

    private void Awake()
    {
        LoadItem();
    }
    private void LoadItem()
    {
        spriteRenderer.sprite = itemData.itemVisual;
        gameObject.name = itemData.itemName;
    }
}
