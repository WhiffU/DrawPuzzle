using System;
using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using AnimationState = Spine.AnimationState;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject sectionHint;
    public Button btnNextLevel;
    public TextMeshProUGUI textLevel;
    public int levelIndex;
    public GameObject[] levels;
    public GameObject level;
    public GameObject panelEndGame;
    public GameObject panelRateUs;
    public GameObject[] greenTick;
    public GameObject[] winningVFXs;

    private bool isHintButtonExists = false;

    public AudioClip buttonSound;


    public void Awake()
    {
        Instance = this;
        AddListenerButtons();
        LoadLevel();
        GenerateLevel();
    }

    private void AddListenerButtons()
    {
        btnNextLevel.onClick.AddListener(PlayNextLevel);
    }

    private void PlayNextLevel()
    {
        SoundManager.Instance.buttonClickSource.PlayOneShot(buttonSound);
        level.GetComponent<Level>().DestroyLevel();
        levelIndex++;

        if (levelIndex < levels.Length)
        {
            GenerateLevel();
        }
        else
        {
            panelEndGame.SetActive(true);
        }
    }

    private void GenerateLevel()
    {
        textLevel.text = "Level " + (levelIndex + 1).ToString();
        var currentLevel = Instantiate(levels[levelIndex], transform.position, quaternion.identity);
        level = currentLevel;
        for (int i = 0; i < greenTick.Length; i++)
        {
            greenTick[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < winningVFXs.Length; i++)
        {
            winningVFXs[i].gameObject.SetActive(false);
        }

        btnNextLevel.gameObject.SetActive(false);
        if (isHintButtonExists) sectionHint.gameObject.SetActive(true);
        //Show Hint after level 2
        ShowHintButton();
    }

    public void CheckWinningCondition()
    {
        level.GetComponent<Level>().LevelComplete();
        SaveLevel();

        //Rate us Pop-up after level 4
        //ShowRateUs();


        for (int i = 0; i < greenTick.Length; i++)
        {
            greenTick[i].gameObject.SetActive(true);
        }

        for (int i = 0; i < winningVFXs.Length; i++)
        {
            winningVFXs[i].gameObject.SetActive(true);
        }
        

        btnNextLevel.gameObject.SetActive(true);
        sectionHint.gameObject.SetActive(false);
    }

    public void SaveLevel()
    {
        PlayerPrefs.SetInt("level", levelIndex);
    }

    private void LoadLevel()
    {
        levelIndex = PlayerPrefs.GetInt("level");
    }

    private void ShowHintButton()
    {
        if (levelIndex >= 2)
        {
            isHintButtonExists = true;
            sectionHint.gameObject.SetActive(true);
        }
    }

    private void ShowRateUs()
    {
        if (levelIndex == 3)
        {
            panelRateUs.SetActive(true);
        }
        else
        {
            panelRateUs.SetActive(false);
        }
    }
}