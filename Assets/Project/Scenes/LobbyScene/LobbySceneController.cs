using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SS.View;

public class LobbySceneController : Controller
{
    public const string LOBBYSCENE_SCENE_NAME = "LobbyScene";

    public override string SceneName()
    {
        return LOBBYSCENE_SCENE_NAME;
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