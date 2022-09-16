using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SaveData
{
    // SceneName
    // player => dungeonlevel hasWeapons[], hasWeaponValue, heart, money inventory(items)
    //

    public Vector3 _position;
    public int _dungeonLevel;
    public bool[] _hasWeapons;
    public int[] _hasWeaponValue;
    public int _heart;
    public int _money;
    public List<InvenItem> _items;
    
    
}
