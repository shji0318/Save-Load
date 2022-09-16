using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UI_Save : UI_Base
{
    enum Buttons
    {
        SaveData0,
        SaveData1,
        SaveData2,
    }

    enum Texts
    {
        SaveData0_Text,
        SaveData1_Text,
        SaveData2_Text,
    }

    public void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));

        Init();
        
    }

    public void Init()
    {
        for (int i = 0; i < SaveDataManager.Instance.ExistData.Length; i++)
        {
            if (SaveDataManager.Instance.ExistData[i] != null)
            {
                SaveData saveData = SaveDataManager.Instance.ExistData[i];
                Get<Text>(i).text = $"던전 레벨 : {saveData._dungeonLevel}\n 획득 골드 : {saveData._money} HP : {saveData._heart}";
            }
            Get<Button>(i).onClick.AddListener(Save);
        }
    }

    public void UpdateData()
    {
        for (int i = 0; i < SaveDataManager.Instance.ExistData.Length; i++)
        {
            if (SaveDataManager.Instance.ExistData[i] != null)
            {
                SaveData saveData = SaveDataManager.Instance.ExistData[i];
                Get<Text>(i).text = $"던전 레벨 : {saveData._dungeonLevel}\n 획득 골드 : {saveData._money} HP : {saveData._heart}";
            }           
        }
    }


    public void Save()
    {
        string path = Path.Combine(Application.dataPath, $"{EventSystem.current.currentSelectedGameObject.name}.json");
        SaveAndLoad.Save(path, Player_knights.instance);
        SaveDataManager.Instance.Init();
        Init();
        Destroy(this.gameObject);
    }

}
