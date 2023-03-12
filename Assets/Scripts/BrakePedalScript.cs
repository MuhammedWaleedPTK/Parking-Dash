using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BrakePedalScript : MonoBehaviour
{
    public bool isPressed;

    


    
    // Start is called before the first frame update
    void Start()
    {
        SetUpButton();              //we set up our button eventTriggers
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    void SetUpButton()
    {
        //we create a new event trigger
        EventTrigger trigger = gameObject.AddComponent<EventTrigger>();

        //we set up a new entry for our event trigger for PointerDown
        var pointerDown = new EventTrigger.Entry();
        pointerDown.eventID = EventTriggerType.PointerDown;
        pointerDown.callback.AddListener((e) => onClickDown());

        //we create an entry for PointerUp as well
        var pointerUp = new EventTrigger.Entry();
        pointerUp.eventID = EventTriggerType.PointerUp;
        pointerUp.callback.AddListener((e) => onClickUp());

        //we push the changes to the EventTrigger
        trigger.triggers.Add(pointerDown);
        trigger.triggers.Add(pointerUp);


    }

    public void onClickDown()
    {
        isPressed = true;
    }

    public void onClickUp()
    {
        isPressed = false;
    }
}
