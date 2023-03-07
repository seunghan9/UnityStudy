using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_Popup
{
    enum Buttons
    {
        PointButton
    }

    enum Texts
    {
        PointText,
        ScoreText
    }

    enum Images
    {
        ItemIcon,
    }

    public void Awake()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Managers.UI.SetCanvas(gameObject, true);

        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<Image>(typeof(Images));

        GetButton((int)Buttons.PointButton).gameObject.AddUIEvent(OnButtonClicked);

        GameObject go = GetImage((int)Images.ItemIcon).gameObject;
        BindUIEvent(go, (PointerEventData data) => { go.transform.position = data.position; }, Define.UIEvent.Drag);
    }

    int _score = 0;
    public void OnButtonClicked(PointerEventData data)
    {
        Debug.Log("Button Clicked");

        ++_score;

        Get<TextMeshProUGUI>((int)Texts.ScoreText).text = $"Á¡¼ö : {_score}";

    }
}
