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
}