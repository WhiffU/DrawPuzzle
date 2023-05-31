using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    private float time, second;
    [SerializeField] private Slider _slider;
    [SerializeField] private GameObject _panelSplashScreen;

    private void Start()
    {
        second = 2;
        Invoke("CloseSplashScreen", second);
    }

    private void Update()
    {
        if (time < second)
        {
            time += Time.deltaTime;
            _slider.value = time / second;
        }
    }

    void CloseSplashScreen()
    {
        _panelSplashScreen.gameObject.SetActive(false);
    }
}