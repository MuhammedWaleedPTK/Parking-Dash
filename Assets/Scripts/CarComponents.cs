using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarComponents: MonoBehaviour
{
    public GameObject needle,needle2;
    public float startingPos = -90f, endPos = 90f;
    public float desiredPos;

    public GameObject frontHighBeam;
    public GameObject frontLowBeam;
    //private bool isLightOn=false;
    private bool isHighLight = false;
    public GameObject LightHightButton;
    public GameObject LightLowButton;
    public Color lightOffColor;

    public float speed;
    public Carcontroller carController;
    private void Start()
    {
        carController= GetComponent<Carcontroller>();
        frontLowBeam.SetActive(false);

    }
    private void Update()
    {
        speed=carController.speed;
        UpdateNeedle();
       
    }

    void UpdateNeedle()
    {
        desiredPos = startingPos - endPos;
        float temp =Mathf.Abs( speed / 280);
        needle.transform.eulerAngles=new Vector3(0,0, startingPos-temp*desiredPos);
       
        needle2.transform.localEulerAngles = new Vector3(0, 0, (-startingPos - temp * desiredPos) + 140f);
    }
   //public  void LightSwitch()
   // {
        
   //     isLightOn=!isLightOn;
   //     frontLights.SetActive(isLightOn);
   //     if(isLightOn)
   //     {
   //         LightButton.image.color = Color.white;
           
   //     }
   //     else
   //     {
   //         LightButton.image.color = lightOffColor;

   //     }
   // }
    public void LightBeam()
    {
        isHighLight=!isHighLight;
        frontHighBeam.SetActive(!isHighLight);
        frontLowBeam.SetActive(isHighLight);
        LightLowButton.SetActive(isHighLight);
        LightHightButton.SetActive(!isHighLight);

    }
}
