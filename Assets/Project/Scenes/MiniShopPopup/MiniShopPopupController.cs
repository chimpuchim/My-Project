using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SS.View;

public class MiniShopPopupController : Controller
{
    public const string MINISHOPPOPUP_SCENE_NAME = "MiniShopPopup";

    public override string SceneName()
    {
        return MINISHOPPOPUP_SCENE_NAME;
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
    
    public void OnBuyPack(int money)
    {
        MoneyManager.Instance.AddMoney(money);
    }
}