using UnityEngine ;
using UnityEngine.UI ;
using DG.Tweening ;
using TMPro;

public class SwitchToggle : MonoBehaviour {
    [SerializeField] private RectTransform uiHandleRectTransform ;
    [SerializeField] private Color backgroundActiveColor ;
    [SerializeField] private Color handleActiveColor ;
    [SerializeField] private string[] handleText;

    private Image backgroundImage, handleImage ;
    private Color backgroundDefaultColor, handleDefaultColor ;
    private Toggle toggle ;
    private Vector2 handlePosition ;
    private TextMeshProUGUI handleTextGet;


    private void Awake () 
    {
        handlePosition = uiHandleRectTransform.anchoredPosition ;

        backgroundImage = uiHandleRectTransform.parent.GetComponent <Image>() ;
        handleImage = uiHandleRectTransform.GetComponent <Image>() ;

        backgroundDefaultColor = backgroundImage.color ;
        handleDefaultColor = handleImage.color ;

        handleTextGet = uiHandleRectTransform.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

    }

    private void Start() 
    {
        toggle = GetComponent <Toggle>() ;

        toggle.onValueChanged.AddListener (OnSwitch) ;


        if (toggle.isOn)
            OnSwitch (true) ;
    }

    private void OnSwitch (bool on) {
        uiHandleRectTransform.DOAnchorPos (on ? handlePosition * -1 : handlePosition, .4f).SetEase (Ease.InOutBack).SetUpdate(true) ;

        backgroundImage.DOColor (on ? backgroundActiveColor : backgroundDefaultColor, .6f).SetUpdate(true) ;

        handleImage.DOColor (on ? handleActiveColor : handleDefaultColor, .4f).SetUpdate(true) ;

        handleTextGet.text = on ? handleText[1] : handleText[0];
    }

    private void OnDestroy ( ) {
        toggle.onValueChanged.RemoveListener (OnSwitch) ;
    }
}
