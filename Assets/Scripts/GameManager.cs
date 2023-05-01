using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Action gameWonAction;
    public static Action gameFailedAction;
    public static Action carFellAction;

    public GameObject needle;
    public static Action<GameObject> carNeedleAction;

    public GameObject gameWonPanel;
    public TextMeshProUGUI gameWonText;
    public bool isGameWon = false;

    public GameObject uiCanvas;

    public GameObject gameFailedPanel;
    public GameObject carFellPanel;
    public bool isGameFailed = false;

    public CarsInfo carsInfo;
    Cars cars;

    public  string CarName;
    public  int motorPower;
    public  int breakPower;
    public  AudioClip engineStartSound;
    public  AudioClip engineIdleSound;
    public  AudioClip engineRunningSound;


    public int carsCount=5;
    public GameObject carsParent;




    public bool isCockpitOn= false;
    public static Action ToggleCockpitCamAction;
    private void Awake()
    {
        //carNeedleAction?.Invoke(needle);
        //Debug.Log("needl1");


       
      

        cars = carsInfo.cars[carsInfo.currentCarId];
        CarName = cars.name;
        motorPower = cars.motorPower;
        breakPower = cars.breakPower;
        engineStartSound = cars.engineStartSound;
        engineIdleSound = cars.engineIdleSound;
        engineRunningSound = cars.engineRunningSound;
        


    }
    private void OnEnable()
    {
        gameWonAction += GameWon;
        gameFailedAction += LevelFailed;
        carFellAction += CarFell;

    }
    private void OnDisable()
    {
        gameWonAction -= GameWon;
        gameFailedAction -= LevelFailed;
        carFellAction -= CarFell;
    }
    private void Start()
    {
        carsParent = GameObject.Find("CarsParent");
        carNeedleAction?.Invoke(needle);
        for (int i = 0; i < carsCount; i++)
        {
            if (i == PlayerPrefs.GetInt("currentCarId",0))
            {
                carsParent.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                carsParent.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    private void Update()
    {
        
    }
    public void GameWon()
    {
        isGameWon= true;
        if (!isGameFailed)
        {
            uiCanvas.SetActive(false);
            gameWonPanel.SetActive(true);
            gameWonText.text = "LEVEL " +( SceneManager.GetActiveScene().buildIndex-2)+ " COMPLETED";
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
       
        ToggleCockpitCamAction?.Invoke();
    }
}
