using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassOfWater : Interactives
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
            if (GUI.Button(new Rect(screenPos.x, screenPos.y, 50, 25), "Take"))
            {
                clickedOn = false;
                viewingGUI = false;
                clickedOnGUI = true;

                gameObject.SetActive(false);
                Inventory.AddItem(gameObject);
                Debug.Log("took glass of water");
            }
        }
    }
}
