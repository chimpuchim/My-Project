using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;
    
    public static SaveManager GetInstance()
    {
        if (Instance is null)
        {
            Instance = new SaveManager();
        }
        return Instance;
    }
    
    public void SaveData(GameDataType gameDataType, int value)
    {
        PlayerPrefs.SetInt(gameDataType.ToString(), value);
        PlayerPrefs.Save();
    }

    public int LoadData(GameDataType gameDataType)
    {
        return PlayerPrefs.GetInt(gameDataType.ToString());
    }

    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
    }
}
