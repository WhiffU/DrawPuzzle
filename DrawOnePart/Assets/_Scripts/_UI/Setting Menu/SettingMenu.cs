using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SettingMenu : MonoBehaviour
{
    [Header("Space between menu items")] [SerializeField]
    private Vector3 spacing;

    [Header("Main button rotation")] [SerializeField]
    private float rotationDuration;

    [SerializeField] private Ease rotationEase;

    [Header("Animation")] [SerializeField] private float expandDuration;

    [SerializeField] private float collapseDuration;
    [SerializeField] private Ease expandEase;
    [SerializeField] private Ease collapseEase;

    [Header("Fading")] [SerializeField] private float expandFadeDuration;

    [SerializeField] private float collapseFadeDuration;

    [SerializeField] private Button mainButton;
    private SettingMenuItem[] _menuItems;
    private bool isExpanded;
    private bool isVibrateOn;
    private bool isMusicOn;
    private bool isSFXOn;

    [SerializeField] private Vector3 mainButtonPosition;
    private int itemsCount;
    public GameObject settingMenuBackground;

    private void Awake()
    {
        isVibrateOn = true;
        isMusicOn = true;
        isSFXOn = true;
    }

    private void Start()
    {
        itemsCount = transform.childCount - 1;
        _menuItems = new SettingMenuItem[itemsCount];
        for (int i = 0; i < itemsCount; i++)
        {
            _menuItems[i] = transform.GetChild(i + 1).GetComponent<SettingMenuItem>();
        }

        mainButton = transform.GetChild(0).GetComponent<Button>();

        mainButton.onClick.AddListener(ToggleMenu);


        mainButton.transform.SetAsLastSibling();

        mainButtonPosition = mainButton.GetComponent<RectTransform>().anchoredPosition;

        //Reset all menu items to mainButtonPosition
        ResetPosition();
    }

    private void ResetPosition()
    {
        for (int i = 0; i < itemsCount; i++)
        {
            _menuItems[i].rectTransform.localPosition = mainButtonPosition;
        }
    }


    void ToggleMenu()
    {
        isExpanded = !isExpanded;

        if (isExpanded)
        {
            //menu opened
            for (int i = 0; i < itemsCount; i++)
            {
                _menuItems[i].rectTransform.DOLocalMove(mainButtonPosition + spacing * (i + 1), expandDuration)
                    .SetEase(expandEase);
                ;

                _menuItems[i].image.DOFade(1f, expandFadeDuration).From(0f);
            }

            settingMenuBackground.gameObject.SetActive(true);
        }
        else
        {
            //menu closed
            for (int i = 0; i < itemsCount; i++)
            {
                _menuItems[i].rectTransform.DOLocalMove(mainButtonPosition, collapseDuration)
                    .SetEase(collapseEase);

                _menuItems[i].image.DOFade(0f, collapseFadeDuration);
            }

            settingMenuBackground.gameObject.SetActive(false);
        }

        //ROTATE MAIN BUTTON

        mainButton.transform.DORotate(Vector3.forward * 360f, rotationDuration, RotateMode.FastBeyond360)
            .From(Vector3.zero)
            .SetEase(rotationEase);

        //Enable Background
    }


    public void OnItemClick(int index)
    {
        switch (index)
        {
            case 0:
                isVibrateOn = !isVibrateOn;
                if (isVibrateOn)
                {
                    Debug.Log("Vibrate");
                    Handheld.Vibrate();
                    _menuItems[0].image.sprite = _menuItems[0].imageOn;
                }
                else
                {
                    Debug.Log("No Vibrate");
                    _menuItems[0].image.sprite = _menuItems[0].imageOff;
                }

                break;
            case 1:
                isMusicOn = !isMusicOn;
                if (isMusicOn)
                {
                    Debug.Log("Music On");
                    _menuItems[1].image.sprite = _menuItems[1].imageOn;
                    SoundManager.Instance.backGroundMusicSource.enabled = true;
                }
                else
                {
                    Debug.Log("Music Off");
                    _menuItems[1].image.sprite = _menuItems[1].imageOff;
                    SoundManager.Instance.backGroundMusicSource.enabled = false;
                }

                break;
            case 2:

                isSFXOn = !isSFXOn;
                if (isSFXOn)
                {
                    Debug.Log("Sound FX On");
                    _menuItems[2].image.sprite = _menuItems[2].imageOn;
                    SoundManager.Instance.drawingSoundSource.enabled = true;
                    SoundManager.Instance.winSoundSource.enabled = true;
                    SoundManager.Instance.buttonClickSource.enabled = true;
                }
                else
                {
                    Debug.Log("Sound FX Off");
                    _menuItems[2].image.sprite = _menuItems[2].imageOff;
                    SoundManager.Instance.drawingSoundSource.enabled = false;
                    SoundManager.Instance.winSoundSource.enabled = false;
                    SoundManager.Instance.buttonClickSource.enabled = false;
                }

                break;

            case 3:
                ShopPanel.Instance.OpenShop();
                break;
        }
    }

    private void OnDestroy()
    {
        mainButton.onClick.RemoveListener(ToggleMenu);
    }
}