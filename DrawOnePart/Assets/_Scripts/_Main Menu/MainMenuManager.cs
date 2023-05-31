using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Button drawModeButton;
    public Button eraseModeButton;

    private void Start()
    {
        drawModeButton.onClick.AddListener(PlayDrawMode);
        eraseModeButton.onClick.AddListener(PlayEraseMode);
    }

    private void PlayDrawMode()
    {
        SceneManager.LoadScene(1);
    }

    private void PlayEraseMode()
    {
        SceneManager.LoadScene(2);
    }
}