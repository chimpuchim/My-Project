using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SS.View;

public class DiscornetPopupController : Controller
{
    public const string DISCORNETPOPUP_SCENE_NAME = "DiscornetPopup";

    public override string SceneName()
    {
        return DISCORNETPOPUP_SCENE_NAME;
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