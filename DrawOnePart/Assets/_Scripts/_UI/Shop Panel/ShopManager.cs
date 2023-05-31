using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance;

    public int cash;
    public int hintNumber;

    public Sprite[] themes;
    public Color[] visualEffects;

    [SerializeField] private TextMeshProUGUI _cashText;
    [SerializeField] private TextMeshProUGUI _hintsText;


    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        _cashText.text = ": " + cash.ToString();
        _hintsText.text = ": " + hintNumber.ToString();
    }
}