using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SS.View;

public class WinPopupController : Controller
{
    public const string WINPOPUP_SCENE_NAME = "WinPopup";

    public override string SceneName()
    {
        return WINPOPUP_SCENE_NAME;
    }
}