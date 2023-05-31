using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraseLevel : MonoBehaviour
{
    public static EraseLevel Instance;

    public GameObject FirstImage;
    public GameObject ErasePart;
    public GameObject Goal;

    private void Awake()
    {
        Instance = this;
    }

    public void CompleteLevel()
    {
        GameManagerEraseMode.Instance.CheckWinningCondition();
        FirstImage.SetActive(false);
        ErasePart.SetActive(false);
        Goal.SetActive(true);
    }
    public void DestroyLevel()
    {
        Destroy(gameObject);
    }
}