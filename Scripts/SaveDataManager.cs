using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveDataManager : MonoBehaviour
{
    private static SaveDataManager instance;    
    public static SaveDataManager Instance { get => instance;}

    private SaveData[] _existData = new SaveData[3];
    public SaveData[] ExistData { get => _existData; set => _existData = value; }    

    private SaveData _inSaveData;
    public SaveData InSaveData { get => _inSaveData; set => _inSaveData = value; }


    string path;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        Init();
    }

    public void Init()
    {
        
        for (int i = 0; i < 3; i++)
        {
            path = Path.Combine(Application.dataPath, $"SaveData{i}.json");
            if (File.Exists(path))
            {
                ExistData[i] = SaveAndLoad.Load(path);
            }
        }
    }

}
