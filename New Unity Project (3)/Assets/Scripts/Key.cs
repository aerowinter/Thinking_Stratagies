using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Interactives
{
    public GameObject Silver_Key;
    public GameObject ashes;
    protected override void Start()
    {
        base.Start();
        isCurrentlyInteractive = true;
        canTake = false;
    }
    protected override void OnGUI()
    {

        base.OnGUI();
        if (viewingGUI)
        {
            if (Inventory.FindItemByName("ashes"))
            {
                canTake = true;
                if (GUI.Button(new Rect(screenPos.x, screenPos.y - 25, 70, 25), "Take key"))
                {
                    clickedOn = false;
                    viewingGUI = false;
                    clickedOnGUI = true;

                    Inventory.AddItem(Silver_Key);
                    Inventory.RemoveItem(ashes);
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
