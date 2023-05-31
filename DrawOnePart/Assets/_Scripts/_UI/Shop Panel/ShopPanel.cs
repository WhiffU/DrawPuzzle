using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{
    public Button buttonClose;
    public static ShopPanel Instance;

    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
        buttonClose.onClick.AddListener(CloseShop);
    }

    public void OpenShop()
    {
        gameObject.SetActive(true);
    }

    private void CloseShop()
    {
        gameObject.SetActive(false);
    }
}