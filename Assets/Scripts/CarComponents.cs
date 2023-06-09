using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarComponents: MonoBehaviour
{
    public GameObject needle,needle2;
    public float startingPos = -90f, endPos = 90f;
    public float desiredPos;

    public GameObject frontLights;
    public GameObject brakeLight;

    public GameObject frontHighBeam;
    public GameObject frontLowBeam;
   
    public bool isHighLight = false;
    
    public Color lightOffColor;

    private float speed;
    private void OnEnable()
    {
        GameManager.carNeedleAction += NeedleAssign;
        FreeDrive.carLightAction += ToggleCarLight;
       
    }
    private void OnDisable()
    {
        GameManager.carNeedleAction -= NeedleAssign;
        FreeDrive.carLightAction -= ToggleCarLight;
       
    }
    public void NeedleAssign(GameObject needle)
    {
        
        this.needle = needle;
       
    }
    private void Start()
    {
        
        frontLowBeam.SetActive(false);

    }
    private void Update()
    {
        speed=Carcontroller.speed;
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
        //LightLowButton.SetActive(isHighLight);
        //LightHightButton.SetActive(!isHighLight);

    }
    private void ToggleCarLight(bool isDay)
    {
        frontLights.SetActive(!isDay);
        brakeLight.SetActive(!isDay);
    }

}
