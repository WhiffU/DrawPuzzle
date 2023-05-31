using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SettingMenuDemo : MonoBehaviour
{
    public GameObject background;
    public Button[] buttons;
    public Button buttonSetting;
    private bool isActive;
    private float rotationDuration = 0.3f;

    private void Start()
    {
        buttonSetting.onClick.AddListener(ToggleMenu);
        isActive = false;
    }

    private void ToggleMenu()
    {
        isActive = !isActive;
        buttonSetting.transform.DORotate(Vector3.forward * 360f, rotationDuration, RotateMode.FastBeyond360)
            .From(Vector3.zero)
            .SetEase(Ease.Linear);

        //Open Menu
        if (isActive)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                background.GetComponent<Image>().gameObject.SetActive(true);
                buttons[i].GetComponent<RectTransform>().DOLocalMoveY(150, 1.5f, false);
            }
        }

        //Close Menu
        else
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                background.GetComponent<Image>().gameObject.SetActive(false);
                buttons[i].gameObject.SetActive(false);
            }
        }
    }
}