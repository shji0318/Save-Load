using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UI_Load : UI_Base
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

        for(int i = 0; i < SaveDataManager.Instance.ExistData.Length; i++)
        {
            if(SaveDataManager.Instance.ExistData[i]!=null)
            {
                SaveData saveData = SaveDataManager.Instance.ExistData[i];
                Get<Text>(i).text = $"던전 레벨 : {saveData._dungeonLevel}\n 획득 골드 : {saveData._money} HP : {saveData._heart}";                
                Get<Button>(i).onClick.AddListener(LoadVillageScene);                
            }
        }
    }

    public void LoadVillageScene()
    {
        int i=0;        
        switch (EventSystem.current.currentSelectedGameObject.name)
        {
            case "SaveData0" :
                {
                    i = (int)Buttons.SaveData0;
                    break;
                }
            case "SaveData1":
                {
                    i = (int)Buttons.SaveData1;
                    break;
                }
            case "SaveData2":
                {
                    i = (int)Buttons.SaveData2;
                    break;
                }
        }
        SaveDataManager.Instance.InSaveData = SaveDataManager.Instance.ExistData[i];
        NextScene.LoadScene("VillageScene");
    }
    
}
