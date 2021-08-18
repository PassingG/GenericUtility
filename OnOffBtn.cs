using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class OnOffBtn : CustomButton
{
    [HideInInspector]
    public bool IsOn;

    [SerializeField]
    private RectTransform m_SwitchIconRect;
    public RectTransform switchIconRect => m_SwitchIconRect;


    [Header("Switch Sprite"), Space(10)]
    [SerializeField]
    private Image SwitchIcon;

    [SerializeField]
    private Sprite OnSprite;

    [SerializeField]
    private Sprite OffSprite;

    public UnityAction onOffClicked;

    protected override void Awake()
    {
        base.Awake();
        
        OnClick += OnClickedBtn;
    }

    public void OnClickedBtn()
    {
        IsOn = !IsOn;

        UpdateUI();

        onOffClicked?.Invoke();
    }

    public void UpdateUI()
    {
        if (IsOn.Equals(true))
        {
            SwitchIcon.sprite = OnSprite;
            iconImage.sprite = clickedSprite;
        }
        else
        {
            SwitchIcon.sprite = OffSprite;
            iconImage.sprite = normalSprite;
        }
    }
}
