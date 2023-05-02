using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject levelPanel;
    public GameObject menuPanel;
    public GameObject modePanel;





    private void Start()
    {
        levelPanel.SetActive(false);
        modePanel.SetActive(false);
        
    }
    public void GamePlay()
    {
        
        levelPanel.SetActive(false);
        menuPanel.SetActive(false);
        modePanel.SetActive(true);
    }
    public void LevelMode()
    {
        levelPanel.SetActive(true);
        menuPanel.SetActive(false);
        modePanel.SetActive(false);
    }
    public void FreeMode()
    {
        SceneManager.LoadScene("FreeDrive01");
    }
    public void BackToMenu()
    {
        levelPanel.SetActive(false);
        menuPanel.SetActive(true);
        modePanel.SetActive(false);
    }
    public void BackToMOde()
    {
        levelPanel.SetActive(false);
        menuPanel.SetActive(false);
        modePanel.SetActive(true);
    }
    public void CarSelection()
    {
        SceneManager.LoadScene("CarSelection");
    }
    public void Quit()
    {
        Application.Quit();
    }
    

}
