using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassOfWater : Interactives
{

    protected override void OnGUI()
    {
        base.OnGUI();
        if (viewingGUI)
        {
            if (GUI.Button(new Rect(screenPos.x, screenPos.y, 50, 25), "Exit"))
            {
                clickedOn = false;
                viewingGUI = false;
                clickedOnGUI = true;
                Debug.Log("clicked on exit");
            }

            if (GUI.Button(new Rect(screenPos.x, screenPos.y - 25, 50, 25), "Take"))
            {
                clickedOn = false;
                viewingGUI = false;
                clickedOnGUI = true;

                Debug.Log("took glass of water");
                Inventory.AddItem(gameObject);
                gameObject.SetActive(false);
            }
        }
    }
}
