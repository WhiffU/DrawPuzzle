using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RateUsPanel : MonoBehaviour
{
    public Button btnClose;

    void Start()
    {
        btnClose.onClick.AddListener(ClosePanel);
    }

    private void OnEnable()
    {
        transform.DOScale(new Vector3(1.5f, 1.5f, 0), 1.5f);
    }

    private void ClosePanel()
    {
        this.gameObject.SetActive(false);
    }
}