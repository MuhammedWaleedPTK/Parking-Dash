using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadObsatcles : MonoBehaviour
{

   

    private void Start()
    {
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Debug.Log("Game Over");
            //Handheld.Vibrate();
           GameManager.gameFailedAction?.Invoke();
            
        }
    }
}
