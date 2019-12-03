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
                    gameObject.GetComponent<CapsuleCollider2D>().size =
                        new Vector2(gameObject.GetComponent<CapsuleCollider2D>().size.y, gameObject.GetComponent<CapsuleCollider2D>().size.y);

                    Inventory.RemoveItemByName("Glass_Of_Water");
                }
            }

            if (anim.GetBool("water"))
            {
                if (GUI.Button(new Rect(screenPos.x, screenPos.y - 25, 70, 25), "Jump down"))
                {
                    clickedOn = false;
                    viewingGUI = false;
                    clickedOnGUI = true;

                    //Scene sceneToLoad = SceneManager.GetSceneByName("LivingRoom");

                    //SceneManager.MoveGameObjectToScene(Inventory.GetItemByName("Ball"), sceneToLoad);
                    SceneManager.LoadScene("LivingRoom");
                }
            }
        }
    }
}
