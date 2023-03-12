using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carEngineSound : MonoBehaviour
{
    public AudioSource runningSound;
    public float runningMaxVolume;
    public float runningMaxPitch;

    public AudioSource idleSound;
    public float idleMaxVolume;
    public float idleMaxPitch;

    public AudioSource reverseSound;
    public float reverseMaxVolume;
    public float reverseMaxPitch;

    public float speedRatio;
    public float speedSign;

    public AudioSource startingSound;
    public bool isEngineRunning = false;

    private Carcontroller carController;

    private void Start()
    {
        carController= GetComponent<Carcontroller>();
        idleSound.volume = 0f;
        runningSound.volume = 0f;
    }
    private void Update()
    {


        if (carController)
        {
            speedRatio = carController.GetSpeedRatio();
            speedSign=Mathf.Sign(speedRatio);
        }
        if (isEngineRunning)
        {
            idleSound.volume = Mathf.Lerp(0.1f, idleMaxVolume, speedRatio);
            if (speedSign > 0f)
            {


                reverseSound.volume = 0f;
               
                runningSound.volume = Mathf.Lerp(0.3f, runningMaxVolume, speedRatio);
                runningSound.pitch = Mathf.Lerp(runningSound.pitch, Mathf.Lerp(0.3f, runningMaxPitch, speedRatio), Time.deltaTime);
            }
            else
            {
                runningSound.volume = 0f;
                
                reverseSound.volume = Mathf.Lerp(0f, reverseMaxVolume,Mathf.Abs( speedRatio));
                reverseSound.pitch = Mathf.Lerp(reverseSound.pitch, Mathf.Lerp(0.2f, reverseMaxPitch, speedRatio), Time.deltaTime);
            }
        }
        else
        {
            idleSound.volume = 0f;
            runningSound.volume = 0f;
            reverseSound.volume = 0f;
        }
    }

    public IEnumerator StartEngine()
    {
        startingSound.Play();
        runningSound.Play();
        reverseSound.Play();
        idleSound.Play();
        carController.isEngineRunning = 1;
        yield return new WaitForSeconds(0.6f);
        isEngineRunning = true;
        yield return new WaitForSeconds(0.4f);
        carController.isEngineRunning = 2;
    }

}
