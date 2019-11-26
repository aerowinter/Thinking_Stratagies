using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Interactives : MonoBehaviour
{
    public static bool clickedOnInteractive = false;

    public bool clickedOn = false;
    public bool clickedOnGUI = false;
    public bool viewingGUI = false;
    protected Vector3 screenPos;

    public GameObject player;
    public PointAndClick2DUserControl playerScript;

    // Start is called before the first frame update
    protected void Start()
    {
        playerScript = player.GetComponent<PointAndClick2DUserControl>();
        Vector3 pos = gameObject.transform.position;
        screenPos = Camera.main.WorldToScreenPoint(pos);
        Debug.Log(screenPos);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.lastInteractedObject != null && playerScript.lastInteractedObject.viewingGUI)
            clickedOnInteractive = true;
        else
            clickedOnInteractive = false;
    }

    void OnMouseDown()
    {
        Debug.Log("interactives mouse down");
        if (playerScript.lastInteractedObject == null || !playerScript.lastInteractedObject.viewingGUI)
        {
            clickedOnInteractive = true;
            if (playerScript.lastInteractedObject != null)
                playerScript.lastInteractedObject.clickedOn = false;

            playerScript.lastInteractedObject = gameObject.GetComponent<Interactives>();
            Debug.Log("clicked on " + playerScript.lastInteractedObject);
            clickedOn = true;
        }
        
    }

    protected virtual void OnGUI()
    {
        if (clickedOn && playerScript.arrived)
            viewingGUI = true;
    }
}
