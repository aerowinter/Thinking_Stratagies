using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

                    anim.SetBool("water", true);
                    gameObject.GetComponent<CapsuleCollider>().height =
                        gameObject.GetComponent<CapsuleCollider>().radius;

                    Inventory.RemoveItemByName("Glass_Of_Water");
                }
            }

            if (anim.GetBool("water"))
            {
                if (GUI.Button(new Rect(screenPos.x, screenPos.y - 50, 70, 25), "Jump down"))
                {
                    clickedOn = false;
                    viewingGUI = false;
                    clickedOnGUI = true;

                    SceneManager.LoadScene("Living Room");
                }
            }
        }
    }
}
