using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public static class SaveAndLoad 
{
    public static void Save(string path, Player_knights player)
    {
        
        SaveData saveData = new SaveData();
        saveData._position = player.transform.position;
        saveData._dungeonLevel = Player_knights.dungeonLevel;
        saveData._hasWeapons = player.hasWeapons;
        saveData._hasWeaponValue = player.hasWeaponValue;
        saveData._heart = player.heart;
        saveData._money = player.heart;
        saveData._items = player.inventory.items;

        string json = JsonUtility.ToJson(saveData,true);
        File.WriteAllText(path, json);
    }

    public static SaveData Load(string path)
    {
        SaveData loadData;        

        string json = File.ReadAllText(path);
        loadData = JsonUtility.FromJson<SaveData>(json);

        return loadData;

    }

    public static void InLoadData (SaveData loadData,Player_knights player)
    {
        player.transform.position = loadData._position;
        Player_knights.dungeonLevel = loadData._dungeonLevel;
        player.hasWeapons = loadData._hasWeapons;
        player.hasWeaponValue = loadData._hasWeaponValue;
        player.heart = loadData._heart;
        player.money = loadData._money;
        player.inventory.items = loadData._items;
    }
}
