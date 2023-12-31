using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SS.View;

public class CollectionPopupController : Controller
{
    public const string COLLECTIONPOPUP_SCENE_NAME = "CollectionPopup";

    public override string SceneName()
    {
        return COLLECTIONPOPUP_SCENE_NAME;
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