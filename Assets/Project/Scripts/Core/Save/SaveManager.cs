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
    
    public void SaveIntData(string name, int value)
    {
        PlayerPrefs.SetInt(name, value);
        PlayerPrefs.Save();
    }

    public int LoadIntData(string name)
    {
        return PlayerPrefs.GetInt(name);
    }
    
    public void SaveStringData(string name, string value)
    {
        PlayerPrefs.SetString(name, value);
        PlayerPrefs.Save();
    }

    public string LoadStringData(string value)
    {
        return PlayerPrefs.GetString(value);
    }
}
