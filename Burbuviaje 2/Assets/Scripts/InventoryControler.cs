using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class InventoryControler : MonoBehaviour
{
    private ItemDictionary itemDictionary;

    public GameObject inventoryPanel;
    public GameObject slotPrefab;
    public int slotCount;
    public GameObject[] itemPrefab; //por ahora es publico para hacer pruebas.

    
    void Start()
    {
        itemDictionary = FindAnyObjectByType<ItemDictionary>();

        for (int i = 0; i < slotCount; i++)
        {
            Instantiate(slotPrefab, inventoryPanel.transform);
            //Slot slot = Instantiate(slotPrefab, inventoryPanel.transform).GetComponent<Slot>();
            //if (i < itemPrefab.Length)
            //{
            //    GameObject item = Instantiate(itemPrefab[i], slot.transform);
            //    item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            //    slot.currentItem = item;
            //}
        }


    }
    public bool AddItem(GameObject itemPrefab)
    {
        //Busco un slot vacio
        foreach(Transform slotTransform in inventoryPanel.transform)
        {
            Slot slot = slotTransform.GetComponent<Slot>();
            if (slot != null && slot.currentItem == null)
            {
                GameObject newItem = Instantiate(itemPrefab, slotTransform);
                newItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                slot.currentItem = newItem;
                return true;
            }
        }
        Debug.Log("El inventario esta lleno");
        return false;
    }

    public List<InventorySaveData> GetInventoryItems()
    {
        List<InventorySaveData> invData = new List<InventorySaveData>();
        foreach(Transform slotTransform  in inventoryPanel.transform)
        {
            Slot slot = slotTransform.GetComponent<Slot>();
            if(slot.currentItem != null)
            {
                Item item = slot.currentItem.GetComponent<Item>();
                invData.Add(new InventorySaveData { itemID = item.ID, slotIndex = slotTransform.GetSiblingIndex() });
            }
        }
        return invData;
    }

    public void SetInventoryItems(List<InventorySaveData> invData)
    {
        //primero limpio el panel del inventario
        foreach(Transform child in inventoryPanel.transform)
        {
            Destroy(child.gameObject);
        }

        //Creo los nuevos slot
        for(int i = 0; i < slotCount; i++)
        {
            Instantiate(slotPrefab, inventoryPanel.transform);
        }

        //Completo con los items salvados
        foreach(InventorySaveData data in invData)
        {
            if (data.slotIndex < slotCount)
            {
                Slot slot = inventoryPanel.transform.GetChild(data.slotIndex).GetComponent<Slot>();
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
