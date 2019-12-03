using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logs : Interactives
{
    protected override void OnGUI()
    {
        isCurrentlyInteractive = true;
        base.OnGUI();
        if (viewingGUI)
        {
            if (Inventory.FindItemByName("Match_Box"))
            {

                if (GUI.Button(new Rect(screenPos.x, screenPos.y - 25, 70, 25), "Light"))
                {
                    clickedOn = false;
                    viewingGUI = false;
                    clickedOnGUI = true;

                    anim.SetBool("fire", true);
                    gameObject.GetComponent<BoxCollider2D>().size =
                        new Vector2(gameObject.GetComponent<BoxCollider2D>().size.y, gameObject.GetComponent<BoxCollider2D>().size.y);

                    Inventory.RemoveItemByName("Match_Box");
                }
            }
            if (anim.GetBool("fire"))
            {
                if (GUI.Button(new Rect(screenPos.x, screenPos.y - 25, 70, 25), "Take key"))
                {
                    clickedOn = false;
                    viewingGUI = false;
                    clickedOnGUI = true;

                }
            }
        }
    }
}

        
