using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadObsatcles : MonoBehaviour
{

    GameManager gameManager;

    private void Start()
    {
        gameManager= FindObjectOfType<GameManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Debug.Log("Game Over");
            Handheld.Vibrate();
            gameManager.LevelFailed();
            
        }
    }
}
