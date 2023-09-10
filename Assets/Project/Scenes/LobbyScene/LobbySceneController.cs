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

    public void OnOpenSceneLv()
    {
        Manager.Load("Lv1");
    }
}