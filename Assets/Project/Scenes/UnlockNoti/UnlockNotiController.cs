using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SS.View;

public class UnlockNotiController : Controller
{
    public const string UNLOCKNOTI_SCENE_NAME = "UnlockNoti";

    public override string SceneName()
    {
        return UNLOCKNOTI_SCENE_NAME;
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