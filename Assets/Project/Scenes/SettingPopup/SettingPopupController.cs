using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SS.View;

public class SettingPopupController : Controller
{
    public const string SETTINGPOPUP_SCENE_NAME = "SettingPopup";

    public override string SceneName()
    {
        return SETTINGPOPUP_SCENE_NAME;
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