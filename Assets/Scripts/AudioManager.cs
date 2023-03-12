using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource Bgm;
    public AudioSource engineIdleSound;
    public AudioSource forwardSound;
    public AudioSource reverseSound;
    bool isMusicOn = true;
    bool isSoundOn = true;
    public float musicVolume = 1f;
    public float SoundVolume = 1f;

    private void Start()
    {
        Bgm.Play();
       
    }
    public void GamePaused()
    {
        Bgm.pitch = 0.5f;
    }
    public void GameResumed()
    {
        Bgm.pitch = 0.75f;
    }

    public void Sound()
    {
        if (isSoundOn)
        {
            reverseSound.Stop();
            forwardSound.Stop();
            engineIdleSound.Stop();

        }
        else
        {
            reverseSound.Play();
            forwardSound.Play();
            engineIdleSound.Play();
        }
        isSoundOn = !isSoundOn;
        
    }
    public void Music()
    {
        if (isMusicOn)
        {
            Bgm.Stop();

        }
        else
        {
            Bgm.Play();
        }
        isMusicOn = !isMusicOn;
    }
}
