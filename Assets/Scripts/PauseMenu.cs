using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject PauseMenuUI;
    public GameObject OtherCanvas;

    private AudioManager audioManager;

    public TextMeshProUGUI musicText;
    public TextMeshProUGUI soundText;
    bool isMusicOn = true;
    bool isSoundOn = true;

    public GameObject settingPanel;
    public bool isSettingOn = false;

    private void Start()
    {
        PauseMenuUI.SetActive(false);
        audioManager=FindObjectOfType<AudioManager>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Pause();

            }
            else
            {
                Resume();
            }
        }
    }
    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        OtherCanvas.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
        audioManager.GamePaused();

    }
    public void Resume()
    {
        isPaused = false;
        PauseMenuUI.SetActive(false);
        OtherCanvas.SetActive(true);
        Time.timeScale = 1f;
        audioManager.GameResumed();
    }
    public void Restart()
    {
        isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
    public void ToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        
    }
    public void Setting()
    {
        if (isSettingOn)
        {
            settingPanel.SetActive(false);
        }
        else
        {
            settingPanel.SetActive(true);
        }
        isSettingOn = !isSettingOn;
    }


    public void ToQuit()
    {
        
        Application.Quit();
    }
    public void SoundControl()
    {
        audioManager.Sound();
        if (isSoundOn)
        {
            soundText.text = "SOUND:OFF";
        }
        else
        {
            soundText.text = "SOUND:ON";
        }
        isSoundOn=!isSoundOn;
    }
    public void MusicControl()
    {
        audioManager.Music();

        if (isMusicOn)
        {
            musicText.text = "MUSIC:OFF";
        }
        else
        {
            musicText.text = "MUSIC:ON";
        }
        isMusicOn = !isMusicOn;
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
