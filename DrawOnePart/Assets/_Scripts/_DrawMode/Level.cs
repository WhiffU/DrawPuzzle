using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public GameObject uncompletedImage;
    public GameObject[] completedImage;
    public GameObject[] tutorialPoints;
    public AudioClip winningSound;
    private bool canPlayWinSFX;

    private void Awake()
    {
        uncompletedImage.SetActive(true);
        for (int i = 0; i < completedImage.Length; i++)
        {
            completedImage[i].SetActive(false);
        }

        for (int i = 0; i < tutorialPoints.Length; i++)
        {
            tutorialPoints[i].GetComponent<SpriteRenderer>().gameObject.SetActive(true);
        }
    }

    public void LevelComplete()
    {
        uncompletedImage.SetActive(false);
        for (int i = 0; i < completedImage.Length; i++)
        {
            completedImage[i].SetActive(true);
            DrawingArea.Instance.gameObject.SetActive(false);
        }

        for (int i = 0; i < tutorialPoints.Length; i++)
        {
            tutorialPoints[i].GetComponent<SpriteRenderer>().gameObject.SetActive(false);
        }

        canPlayWinSFX = true;
        PlayWinSound();
    }

    private void PlayWinSound()
    {
        if (canPlayWinSFX)
        {
            SoundManager.Instance.winSoundSource.PlayOneShot(winningSound);
        }
        else
        {
            SoundManager.Instance.winSoundSource.Stop();
        }
    }

    public void DestroyLevel()
    {
        Destroy(gameObject);
    }
}