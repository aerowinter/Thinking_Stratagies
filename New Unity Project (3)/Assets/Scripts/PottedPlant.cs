using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PottedPlant : Interactives
{

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnGUI()
    {
        base.OnGUI();
        if (viewingGUI)
        {
            if (GUI.Button(new Rect(screenPos.x, screenPos.y, 50, 25), "Click"))
            {
                clickedOn = false;
                viewingGUI = false;
                clickedOnGUI = true;
                Debug.Log("clicked on button");
            }

            if (Inventory.FindItemByName("Glass_Of_Water"))
            {
                Debug.Log("you have glass of water");

                if (GUI.Button(new Rect(screenPos.x, screenPos.y - 25, 70, 25), "Use water"))
                {
                    clickedOn = false;
                    viewingGUI = false;
                    clickedOnGUI = true;
                    Debug.Log("clicked on button");
                }
            }
        }
    }
}
