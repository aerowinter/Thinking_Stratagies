﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactives : MonoBehaviour
{
    public bool isCurrentlyInteractive = false;

    public static bool clickedOnInteractive = false;

    public bool canTake = false;

    public bool clickedOn = false;
    public bool clickedOnGUI = false;
    public bool viewingGUI = false;
    protected Vector3 screenPos;

    public GameObject player;
    public PointAndClick2DUserControl playerScript;

    public Animator anim;

    // Start is called before the first frame update
    protected virtual void Start()
    {

        playerScript = player.GetComponent<PointAndClick2DUserControl>();
        Vector3 pos = gameObject.transform.position;
        pos.y = -pos.y;
        screenPos = Camera.main.WorldToScreenPoint(pos);
        Debug.Log(screenPos);
    }

    protected void RecalculateScreenPos()
    {
        Vector3 pos = gameObject.transform.position;
        pos.y = -pos.y;
        screenPos = Camera.main.WorldToScreenPoint(pos);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (playerScript.lastInteractedObject != null && playerScript.lastInteractedObject.viewingGUI)
        {
            if (clickedOnInteractive == false)
                Debug.Log("clickedOnInteractive to true");
            clickedOnInteractive = true;
        }
        else if(!playerScript.clicked)
        {
            if(clickedOnInteractive == true)
                Debug.Log("clickedOnInteractive to false");
            clickedOnInteractive = false;
        }

        //OnMouseDown();
    }

    protected void OnMouseDown()
    {
        if (isCurrentlyInteractive)
        {
            if (playerScript.lastInteractedObject == null || !playerScript.lastInteractedObject.viewingGUI)
            {
                clickedOnInteractive = true;
                if (playerScript.lastInteractedObject != null)
                {
                    Debug.Log("last interacted object was not null");
                    playerScript.lastInteractedObject.clickedOn = false;
                }
                    


                playerScript.lastInteractedObject = gameObject.GetComponent<Interactives>();
                Debug.Log("clicked on " + playerScript.lastInteractedObject);
                clickedOn = true;
                playerScript.clicked = true;
            }
        }
    }

    protected virtual void OnGUI()
    {
        if (clickedOn && playerScript.arrived)
            viewingGUI = true;

        if (viewingGUI)
        {

            if (GUI.Button(new Rect(screenPos.x, screenPos.y, 50, 25), "Exit"))
            {
                clickedOn = false;
                viewingGUI = false;
                clickedOnGUI = true;
                Debug.Log("clicked on exit");
            }

            //only show if you can take this item
            if (canTake)
            {
                if (GUI.Button(new Rect(screenPos.x, screenPos.y - 25, 50, 25), "Take"))
                {
                    clickedOn = false;
                    viewingGUI = false;
                    clickedOnGUI = true;

                    Debug.Log("took " + gameObject.name);
                    Inventory.AddItem(gameObject);
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
