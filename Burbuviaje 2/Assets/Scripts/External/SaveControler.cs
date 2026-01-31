using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

public class SaveControler : MonoBehaviour
{
    private string saveLocation;
    private InventoryControler inventoryControler;
    private HotbarControler hotbarControler;
    private Chest[] Chests;

    void Start()
    {
        //Defino donde se va a guardar el archivo con los datos
        saveLocation = Path.Combine(Application.persistentDataPath, "savedata.json");
        //inventoryControler = FindAnyObjectByType<InventoryControler>();
        inventoryControler = FindFirstObjectByType<InventoryControler>();
        hotbarControler = FindFirstObjectByType<HotbarControler>();
        Chests = FindObjectsByType<Chest>(FindObjectsSortMode.None);

    }

    private List<ChestSaveData> GetChetsState()
    {
        List<ChestSaveData> chestsState = new List<ChestSaveData>();

        foreach(Chest chest in Chests)
        {
            ChestSaveData chestSaveData = new ChestSaveData
            {
                ChestID = chest.ChestID,
                IsOpened = chest.IsOpened
            };
            chestsState.Add(chestSaveData);

        }
        return chestsState;
    }

    private void LoadChestsState(List<ChestSaveData> chestSates)
    {
        foreach(Chest chest in Chests)
        {
            ChestSaveData chestSaveData = chestSates.FirstOrDefault(c => c.ChestID == chest.ChestID);

            if (chestSaveData != null)
            {
                chest.SetOpened(chestSaveData.IsOpened);    
            }
        }
    }

    public void saveGame()
    {
        SaveData saveData = new SaveData
        {
            playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position,
            inventorySaveData = inventoryControler.GetInventoryItems(),
            hotbarSaveData = hotbarControler.GetHotbarItems(),
            chestSaveData = GetChetsState()

        };

        File.WriteAllText(saveLocation, JsonUtility.ToJson(saveData));
    }

    public void loadGame()
    {
        if (File.Exists(saveLocation))
        {
            SaveData saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(saveLocation));
            GameObject.FindGameObjectWithTag("Player").transform.position = saveData.playerPosition;
            inventoryControler.SetInventoryItems(saveData.inventorySaveData);
            hotbarControler.SetHotbarItems(saveData.hotbarSaveData);
            LoadChestsState(saveData.chestSaveData);
        }
    }
}
