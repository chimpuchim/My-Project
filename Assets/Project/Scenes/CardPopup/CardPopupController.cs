using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SS.View;

public class CardPopupController : Controller
{
    public const string CARDPOPUP_SCENE_NAME = "CardPopup";

    public override string SceneName()
    {
        return CARDPOPUP_SCENE_NAME;
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