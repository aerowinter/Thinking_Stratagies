using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactives
{
    protected override void Start()
    {
        base.Start();
        isCurrentlyInteractive = true;
    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void OnGUI()
    {
        base.OnGUI();
        if (viewingGUI)
        {
            if (Inventory.FindItemByName("Silver_Key"))
            {
                if (GUI.Button(new Rect(screenPos.x, screenPos.y - 25, 70, 25), "Use key"))
                {
                    clickedOn = false;
                    viewingGUI = false;
                    clickedOnGUI = true;

                    anim.SetBool("open", true);
                    

                    Inventory.RemoveItemByName("Silver_Key");
                }
            }
        }
    }
}
