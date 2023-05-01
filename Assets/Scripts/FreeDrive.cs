using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeDrive : MonoBehaviour
{
    public Light directionalLight; // The directional light in the scene

    public Material dayMaterial; // The material to use for day
    public Material nightMaterial; // The material to use for night
    public GameObject frontLights;
    public GameObject ReverseLights;
    public GameObject LightLowButton;
    public GameObject LightHightButton;

    public static Action<bool> carLightAction;


    private Quaternion dayRotation = Quaternion.Euler(new Vector3(52.4211769f, 109.747101f, 146.139084f)); // The rotation for day
    private Quaternion nightRotation = Quaternion.Euler(new Vector3(350.240692f, 163.654541f, 246.992569f)); // The rotation for night
    private bool isDay = true; // Whether it is currently day or night

    public void ToggleDayNight()
    {
       
        isDay = !isDay;
        carLightAction?.Invoke(isDay);
        Quaternion targetRotation = isDay ? dayRotation : nightRotation;
        // Set the rotation of the directional light immediately to the target rotation
        directionalLight.transform.rotation = targetRotation;
        // Set the material of the environment to the appropriate material based on the time of day

        RenderSettings.skybox = isDay ? dayMaterial : nightMaterial;
        //frontLights.SetActive(!isDay ? true : false);
        //ReverseLights.SetActive(!isDay ? true : false);
    }
    CarComponents carComponents;
    private void Start()
    {
        carComponents=FindObjectOfType<CarComponents>();
    }
    public void ToggleLightBeam()
    {
        carComponents.LightBeam();
        LightLowButton.SetActive(carComponents. isHighLight);
        LightHightButton.SetActive(!carComponents.isHighLight);
    }


}
