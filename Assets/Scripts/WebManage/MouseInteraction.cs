using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static GlobalVariables;

public class MouseInteraction : MonoBehaviour
{
    public TextMeshProUGUI mouthEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouthEvent.text = "Mouse Interaction" + pointingPos + handEvent + gestureEvent;

        GlobalVariables.pointingPos = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
            GlobalVariables.handEvent = 1;
        else if(Input.GetMouseButtonUp(0))
            GlobalVariables.handEvent = 0;

        if (Input.GetKeyDown(KeyCode.Z))
            gestureEvent = gestureType.raiseHandLeft;
        else if (Input.GetKeyDown(KeyCode.X))
            gestureEvent = gestureType.raiseHandRight;
        else if (Input.GetKeyDown(KeyCode.A))
            gestureEvent = gestureType.swipeLeft;
        else if (Input.GetKeyDown(KeyCode.S))
            gestureEvent = gestureType.swipeRight;
    }
}
