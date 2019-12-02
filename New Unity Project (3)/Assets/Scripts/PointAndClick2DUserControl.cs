using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

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
                lastInteractedObject.viewingGUI = false;
            else
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (lastInteractedObject != null && lastInteractedObject.clickedOnGUI)
                lastInteractedObject.clickedOnGUI = false;

        }
        
        if (transform.position.x == target.x)
        {
            anim.SetBool("arrived", true);
            arrived = true;
        }
        else
        {
            anim.SetBool("arrived", false);
            arrived = false;

            if (target.x > transform.position.x)
                anim.SetBool("wentRight", true);
            else
                anim.SetBool("wentRight", false);
        }
        MoveHorizontallyTowards(ref target.x);

    }

    void MoveHorizontallyTowards(ref float xDestination)
    {
        float roomWidth = roomBackgroundModel.GetComponent<RectTransform>().rect.width;
        float playerWidth = playerModel.GetComponent<RectTransform>().rect.width;

        if (xDestination > roomWidth / 2 - playerWidth / 2)
            xDestination = roomWidth / 2 - playerWidth / 2;
        else if (xDestination < -roomWidth / 2 + playerWidth / 2)
            xDestination = -roomWidth / 2 + playerWidth / 2;

        

        transform.position = Vector2.MoveTowards(transform.position, new Vector2(xDestination, transform.position.y), speed * Time.deltaTime);
    }
}
