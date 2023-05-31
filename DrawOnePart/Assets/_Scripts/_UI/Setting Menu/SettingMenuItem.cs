using System;
using UnityEngine;
using UnityEngine.UI;


public class SettingMenuItem : MonoBehaviour
{
    public Image image;
    public RectTransform rectTransform;
    private SettingMenu _settingMenu;
    private Button _button;
    private int index;
    public Sprite imageOn;
    public Sprite imageOff;

    public static SettingMenuItem Instance;
    public AudioClip buttonSound;


    private void Awake()
    {
        Instance = this;
        image = GetComponent<Image>();
        _button = GetComponent<Button>();
        rectTransform.position = Vector3.zero;
        _settingMenu = rectTransform.parent.GetComponent<SettingMenu>();
        index = rectTransform.GetSiblingIndex() - 1;
        AddListenerButtons();
    }

    private void AddListenerButtons()
    {
        _button.onClick.AddListener(OnItemClick);
    }

    void OnItemClick()
    {
        _settingMenu.OnItemClick(index);
        PlayButtonSound();
    }

    private void OnDestroy()
    {
        RemoveListenerButtons();
    }

    private void RemoveListenerButtons()
    {
        _button.onClick.RemoveListener(OnItemClick);
    }


    private void PlayButtonSound()
    {
        if (SoundManager.Instance.buttonClickSource.isPlaying)
        {
            SoundManager.Instance.buttonClickSource.Pause();
        }
        else
        {
            SoundManager.Instance.buttonClickSource.PlayOneShot(buttonSound);
        }
    }
}