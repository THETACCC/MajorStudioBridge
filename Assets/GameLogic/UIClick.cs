using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIClick : MonoBehaviour
{

    public GameObject myUI;
    // Start is called before the first frame update
    void Start()
    {
        // Get the Image component attached to this GameObject
        //myImage = GetComponent<Image>();

        // Get the EventTrigger component attached to this GameObject
        EventTrigger trigger = GetComponent<EventTrigger>();
        if (trigger == null)
        {
            trigger = gameObject.AddComponent<EventTrigger>();
        }

        // Create a new Entry for the PointerClick event
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((eventData) => { DisableImage(); });

        // Add the entry to the EventTrigger
        trigger.triggers.Add(entry);
    }

    // Function to disable the image
    void DisableImage()
    {

            this.gameObject.SetActive(false);
            myUI.SetActive(false);

    }
}
