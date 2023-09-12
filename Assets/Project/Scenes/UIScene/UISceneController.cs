using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SS.View;

public class UISceneController : Controller
{
    public const string UISCENE_SCENE_NAME = "UIScene";
    
    [Header("In game")]
        [SerializeField] private GameObject[] turnOffStartObjs;
    

    public override string SceneName()
    {
        return UISCENE_SCENE_NAME;
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

    public void OnStartBattle()
    {
        foreach (GameObject turnOffStartObj in turnOffStartObjs)
        {
            turnOffStartObj.SetActive(false);
        }
        
        GameController.Instance.IsStartBattle = true;
    }
    
    public void OnBuyUnit(string name)
    {
        PlayerYardController.Instance.BuyUnit(name);
    }
}