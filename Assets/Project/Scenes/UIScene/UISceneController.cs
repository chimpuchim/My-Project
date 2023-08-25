using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SS.View;

public class UISceneController : Controller
{
    public const string UISCENE_SCENE_NAME = "UIScene";
    
    [SerializeField] private GameObject staticCanvas;

    public override string SceneName()
    {
        return UISCENE_SCENE_NAME;
    }

    public void OnStartBattle()
    {
        staticCanvas.SetActive(false);
        GameController.Instance.IsStartBattle = true;
    }
}