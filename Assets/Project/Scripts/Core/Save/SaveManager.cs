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
    
    public void SaveData(DataType dataType, int value)
    {
        PlayerPrefs.SetInt(dataType.ToString(), value);
        PlayerPrefs.Save();
    }

    public int LoadData(DataType dataType)
    {
        return PlayerPrefs.GetInt(dataType.ToString());
    }

    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
    }
}
