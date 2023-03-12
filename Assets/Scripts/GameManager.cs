using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameWonPanel;
    public TextMeshProUGUI gameWonText;
    public bool isGameWon = false;

    public GameObject uiCanvas;

    public GameObject gameFailedPanel;
    public GameObject carFellPanel;
    public bool isGameFailed = false;

    Carcontroller carController;

    public GameObject forwardCamera;
    public GameObject reverseCamera;
    public GameObject CockpitCamera;
    public bool isCockpitOn= false;
    private void Start()
    {
        carController=FindObjectOfType<Carcontroller>();
        reverseCamera.SetActive(false);
    }

    private void Update()
    {
        if (carController.speed < -1)
        {
            reverseCamera.SetActive(true);
            forwardCamera.SetActive(false);
        }
        else
        {
            forwardCamera.SetActive(true);
            reverseCamera.SetActive(false);
        }
    }
    public void GameWon()
    {
        isGameWon= true;
        if (!isGameFailed)
        {
            uiCanvas.SetActive(false);
            gameWonPanel.SetActive(true);
            gameWonText.text = "LEVEL " +( SceneManager.GetActiveScene().buildIndex-1)+ " COMPLETED";
        }
       
    }
    public void LevelFailed()
    {
        isGameFailed = true;
        if (!isGameWon)
        {
           
            uiCanvas.SetActive(false);
            gameFailedPanel.SetActive(true);
        }
        
    }
    public void CarFell()
    {
        isGameFailed = true;
        if (!isGameWon)
        {

            uiCanvas.SetActive(false);
            carFellPanel.SetActive(true);
        }

    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void CameraSwitch()
    {
        isCockpitOn = !isCockpitOn;
        CockpitCamera.SetActive(isCockpitOn);
        
    }
}
