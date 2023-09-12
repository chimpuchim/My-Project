using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SS.View;
using TMPro;

public class WinPopupController : Controller
{
    public const string WINPOPUP_SCENE_NAME = "WinPopup";
    
    [Header("In game")]
        [SerializeField] private TextMeshProUGUI goldText;


    private void Awake()
    {
        goldText.text = "+" + GameController.Instance.CoinLevel;
    }

    public override string SceneName()
    {
        return WINPOPUP_SCENE_NAME;
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

    public void OnClaimGold(int xCoin)
    {
        MoneyManager.Instance.AddMoney(GameController.Instance.CoinLevel * xCoin);
        OnLoadScene("Lv1");
    }
}