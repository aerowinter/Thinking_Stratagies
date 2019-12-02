using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PottedPlant : Interactives
{

    protected override void OnGUI()
    {
        base.OnGUI();
        if (viewingGUI)
        {
            if (Inventory.FindItemByName("Glass_Of_Water"))
            {
                if (GUI.Button(new Rect(screenPos.x, screenPos.y - 25, 70, 25), "Use water"))
                {
                    clickedOn = false;
                    viewingGUI = false;
                    clickedOnGUI = true;

                    anim.SetTrigger("water");

                    Inventory.RemoveItemByName("Glass_Of_Water");
                    //TODO put animation for plant growing here & crash through the floor
                }
            }
        }
    }
}
