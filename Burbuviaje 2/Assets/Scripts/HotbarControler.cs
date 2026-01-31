using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HotbarControler : MonoBehaviour
{
    public GameObject hotbarPanel;
    public GameObject slotPrefab;
    public int slotCount = 10;

    private ItemDictionary itemDictionary;

    private Key[] hotbarKeys;

    private void Awake()
    {
        itemDictionary = FindFirstObjectByType<ItemDictionary>();

        hotbarKeys = new Key[slotCount];

        //hotbarKeys[0] = (Key)((int)Key.Digit1);
        //hotbarKeys[1] = (Key)((int)Key.Digit2);
        //hotbarKeys[2] = (Key)((int)Key.Digit3);
        //hotbarKeys[3] = (Key)((int)Key.Digit4);
        //hotbarKeys[4] = (Key)((int)Key.Digit5);
        //hotbarKeys[5] = (Key)((int)Key.Digit6);
        //hotbarKeys[6] = (Key)((int)Key.Digit7);
        //hotbarKeys[7] = (Key)((int)Key.Digit8);
        //hotbarKeys[8] = (Key)((int)Key.Digit9);
        //hotbarKeys[9] = (Key)((int)Key.Digit0);

        for (int i = 0; i < slotCount; i++)
        {
            //Esto es par asignar las teclas del 1 al 0
            hotbarKeys[i] = i < 9 ? (Key)((int)Key.Digit1 + i) : Key.Digit0;
            //Creo los slot
            Instantiate(slotPrefab, hotbarPanel.transform);
        }
       


    }

    // Update is called once per frame
    void Update()
    {
        //Reviso si se presiono alguna tecla
        for (int i = 0; i < slotCount; i++)
        {
            if (Keyboard.current[hotbarKeys[i]].wasPressedThisFrame) 
            {
                Debug.Log($"Se presiono la tecla {i}");
                //UseItem
                UseItemInSlot(i);
            }
        }
    }

    void UseItemInSlot(int index)
    {
        Slot slot = hotbarPanel.transform.GetChild(index).GetComponent<Slot>();
        if (slot.currentItem != null)
        {
            Item item = slot.currentItem.GetComponent<Item>();
            item.UseItem();
        }
    }

    public List<InventorySaveData> GetHotbarItems()
    {
        List<InventorySaveData> hotbarData = new List<InventorySaveData>();
        foreach (Transform slotTransform in hotbarPanel.transform)
        {
            Slot slot = slotTransform.GetComponent<Slot>();
            if (slot.currentItem != null)
            {
                Item item = slot.currentItem.GetComponent<Item>();
                hotbarData.Add(new InventorySaveData { itemID = item.ID, slotIndex = slotTransform.GetSiblingIndex() });
            }
        }
        return hotbarData;
    }

    public void SetHotbarItems(List<InventorySaveData> hotbarData)
    {
        //primero limpio el panel del inventario
        foreach (Transform child in hotbarPanel.transform)
        {
            Destroy(child.gameObject);
        }

        //Creo los nuevos slot
        for (int i = 0; i < slotCount; i++)
        {
            Instantiate(slotPrefab, hotbarPanel.transform);
        }

        //Completo con los items salvados
        foreach (InventorySaveData data in hotbarData)
        {
            if (data.slotIndex < slotCount)
            {
                Slot slot = hotbarPanel.transform.GetChild(data.slotIndex).GetComponent<Slot>();
                GameObject itemPrefab = itemDictionary.GetItemPrefab(data.itemID);
                if (itemPrefab != null)
                {
                    GameObject item = Instantiate(itemPrefab, slot.transform);
                    item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                    slot.currentItem = item;

                }
            }
        }
    }
}
