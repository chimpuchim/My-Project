using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SS.View;

public class LosePopupController : Controller
{
    public const string LOSEPOPUP_SCENE_NAME = "LosePopup";

    public override string SceneName()
    {
        return LOSEPOPUP_SCENE_NAME;
    }

    public void OnLoadScene(string sceneName)
    {
        Manager.Load(sceneName);
    }
}