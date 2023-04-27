using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Car", menuName = "Cars")] 

public class CarsInfo:ScriptableObject
{
    public Cars[] cars;
    public  int currentCarId;

    public int carsCount() { return cars.Length; }

    public Cars getCar(int index)
    {
        return cars[index];
    }
}



[System.Serializable]
public class Cars
{
    public string name;
    public int motorPower;
    public int breakPower;
    public AudioClip engineStartSound;
    public AudioClip engineIdleSound;
    public AudioClip engineRunningSound;
    

}
