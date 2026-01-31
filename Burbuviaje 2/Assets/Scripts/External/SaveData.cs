using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[System.Serializable]

public class SaveData 
{
    public Vector3 playerPosition;
    public List<InventorySaveData> inventorySaveData;
    public List<InventorySaveData> hotbarSaveData;
    public List<ChestSaveData> chestSaveData;

}

[System.Serializable]

public class ChestSaveData
{
    public string ChestID;
    public bool IsOpened;
}
