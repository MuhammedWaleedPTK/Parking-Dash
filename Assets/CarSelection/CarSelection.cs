using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelection : MonoBehaviour
{
    public GameObject carsParent;
    public CarsInfo carsInfo;
    private int selectionCount = 0;
    public int carsCount = 4;
    // Start is called before the first frame update
    void Start()
    {
        
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
        //Cars car = carsInfo.cars[selectionCount];
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
       
    }
    private void Update()
    {
         if(Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            BackOption();

            Debug.Log("back"+selectionCount+"    slfhj"+ carsInfo.carsCount());
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextOption();
            Debug.Log("next");
        }
    }

}

