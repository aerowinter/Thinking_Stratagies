﻿using System.Collections;
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
            arrived = true;
        }
        else
        {
            arrived = false;
        }
        
    }
}
