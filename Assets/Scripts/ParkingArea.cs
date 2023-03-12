using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingArea : MonoBehaviour
{
    public bool carIsInside;
    public Material parkingMat;
    public Color redColor;
    public Color color;
    bool allCollidersInside = true;
    public bool isGameWon = false;
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        parkingMat.color =redColor;
        parkingMat.SetColor("_EmissionColor", redColor);
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
             allCollidersInside = true;
            Collider[] carColliders = other.GetComponentsInChildren<Collider>();
            Bounds parkingBounds = GetComponent<Collider>().bounds;

            foreach (Collider carCollider in carColliders)
            {
                Bounds carBounds = carCollider.bounds;
                bool colliderInside = parkingBounds.Contains(carBounds.min) && parkingBounds.Contains(carBounds.max);
                allCollidersInside = allCollidersInside && colliderInside;
            }

            carIsInside = allCollidersInside;
            if(carIsInside)
            {
                parkingMat.color = color ;
                parkingMat.SetColor("_EmissionColor", color);
                StartCoroutine(GameWon());
            }
            else 
            {
                carIsInside = false;
                parkingMat.color = redColor;
                parkingMat.SetColor("_EmissionColor", redColor);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
           
        }
    }
    public IEnumerator GameWon()
    {
        yield return new WaitForSeconds(2);
        if (allCollidersInside&&!isGameWon) 
        {

            isGameWon = true;
            Debug.Log("won");
            gameManager.GameWon();
        } 

    }
}
