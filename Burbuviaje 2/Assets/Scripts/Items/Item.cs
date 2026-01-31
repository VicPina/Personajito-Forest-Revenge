using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item Information")]
    public ItemData itemData;
    [Header("Item Functionality")]
    public SpriteRenderer spriteRenderer;

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
