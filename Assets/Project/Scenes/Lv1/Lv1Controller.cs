using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SS.View;

public class Lv1Controller : Controller
{
    public const string LV1_SCENE_NAME = "Lv1";

    public override string SceneName()
    {
        return LV1_SCENE_NAME;
    }

    private void Awake()
    {
        OnAddScene("UIScene");
    }

    public void OnLoadScene(string sceneName)
    {
        Manager.Load(sceneName);
    }
    
    public void OnAddScene(string sceneName)
    {
        Manager.Add(sceneName);
    }
    
    public void OnClose()
    {
        Manager.Close();
    }
}