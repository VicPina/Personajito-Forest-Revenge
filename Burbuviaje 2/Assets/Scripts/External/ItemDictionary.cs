using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class ItemDictionary : MonoBehaviour
{
    public List<Item> itemPrefabs;
    private Dictionary<int, GameObject> itemDictionary;

    private void Awake()
    {
        itemDictionary = new Dictionary<int, GameObject>();

        //Autoincremento de ID
        for (int i = 0; i < itemPrefabs.Count; i++)
        {
            if(itemPrefabs[i] != null)
            {
                itemPrefabs[i].ID = i + 1;

            }
        }

        foreach(Item item in itemPrefabs)
        {
            itemDictionary[item.ID] = item.gameObject;
        }

    }
    public GameObject GetItemPrefab(int itemId)
     { 
        itemDictionary.TryGetValue(itemId, out GameObject prefab);
        if(prefab == null)
        {
            Debug.LogWarning($"El item numero {itemId} no existe en el dicionario");
        }
        return prefab;
     }

}
