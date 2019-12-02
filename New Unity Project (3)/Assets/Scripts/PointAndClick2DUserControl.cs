using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndClick2DUserControl : MonoBehaviour
{
    public bool arrived = false;
    public float speed = 4.5f;
    private Vector2 target;
    public Interactives lastInteractedObject;
    public GameObject roomBackgroundModel;
    public GameObject playerModel;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //if user did not click on an interactive item, reset last item the user clicked
            if (lastInteractedObject != null && Interactives.clickedOnInteractive == false)
            {
                Debug.Log("did not click on interactive");
                lastInteractedObject.clickedOn = false;
                lastInteractedObject.viewingGUI = false;
            }

            Debug.Log("Point&Click");
            if (lastInteractedObject != null && lastInteractedObject.viewingGUI)
            {
                lastInteractedObject.viewingGUI = false;
            }
            else
            {
                float roomWidth = roomBackgroundModel.GetComponent<RectTransform>().rect.width;
                float playerWidth = playerModel.GetComponent<RectTransform>().rect.width;
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (target.x > roomWidth / 2 - playerWidth / 2)
                    target.x = roomWidth / 2 - playerWidth / 2;
                else if (target.x < -roomWidth / 2 + playerWidth / 2)
                    target.x = -roomWidth / 2 + playerWidth / 2;

                if (target.x > transform.position.x)
                    anim.SetBool("wentRight", true);
                else
                    anim.SetBool("wentRight", false);

                target.y = transform.position.y;

            }
            if (lastInteractedObject != null && lastInteractedObject.clickedOnGUI)
            {
                lastInteractedObject.clickedOnGUI = false;
            }
            
        }
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);


        if (transform.position.x == target.x)
        {
            anim.SetBool("arrived", true);
            arrived = true;
        }
        else
        {
            

            anim.SetBool("arrived", false);
            arrived = false;
        }
        
    }
}
