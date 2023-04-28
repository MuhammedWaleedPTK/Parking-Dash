using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarSelection : MonoBehaviour
{
    public GameObject carsParent;
    public CarsInfo carsInfo;
    private int selectionCount;
    public int carsCount = 4;


    public TextMeshProUGUI carNameText;
    public TextMeshProUGUI selectButtonText;


    // Start is called before the first frame update
    void Awake()
    {
        selectionCount = carsInfo.currentCarId;
        UpdateCars(selectionCount);
    }
    public void NextOption()
    {
        selectionCount++;
        if(selectionCount >=carsInfo.carsCount())
        {
            selectionCount = 0;
        }
        UpdateCars(selectionCount);
    }
    public void BackOption()
    {
        selectionCount--;
        if(selectionCount < 0) 
        {
            selectionCount=carsInfo.carsCount()-1;
        }
        UpdateCars(selectionCount);
    }
    private void UpdateCars(int selectionCount)
    {
        Cars car = carsInfo.cars[selectionCount];
        if (selectionCount == PlayerPrefs.GetInt("currentCarId")) 
        {
            selectButtonText.text = "SELECTED";
        }
        else
        {
            selectButtonText.text = "SELECT";
        }
      
        carNameText.text = car.name;
        for(int i = 0; i < carsCount; i++)
        {
            if(i==selectionCount)
            {
                carsParent.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                carsParent.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        Debug.Log(car.name);
       
    }

    public void SelectCar()
    {
        carsInfo.currentCarId = selectionCount;
        PlayerPrefs.SetInt("currentCarId", selectionCount);
        selectButtonText.text = "SELECTED";
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            BackOption();

            Debug.Log("back" + selectionCount + "    slfhj" + carsInfo.carsCount());
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextOption();
            Debug.Log("next");
        }
    }

}

