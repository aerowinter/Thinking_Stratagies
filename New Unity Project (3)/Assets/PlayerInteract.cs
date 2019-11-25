using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject currentInterObj = null;
    public InteractionObject currentInterObjScript = null;
    public Inventory inventory;


    void Update()
    {
     if(Input.GetButtonDown ("Interact") && currentInterObj){
            //Check to see if this object is to be stored in inventory
            if (currentInterObjScript.inventory) {
                inventory.AddItem(currentInterObj);
            }

           //Check to see if this object can be opened
           if(currentInterObjScript.openable) {

                //Check to see if the object is locked
                if(currentInterObjScript.locked) {

                    //Check to see if we have the object needed to unlock
                    //Search inventory for the item needed - if found unlock object
                    if (inventory.FindItem(currentInterObjScript.itemNeeded)) {
                        //We found the item needed
                        currentInterObjScript.locked = false;
                        Debug.Log(currentInterObj.name + " was unlocked");
                    } else {
                        Debug.Log(currentInterObj.name + " was not unlocked");
                    }
                } else {
                    //object is not locked and we want to open the object
                    Debug.Log(currentInterObj.name + " is unlocked");
                    currentInterObjScript.Open();
                }
            }
            //Check to see if this object can be watered
            if (currentInterObjScript.waterable) {

                //Check to see if the object is thirsty
                if(currentInterObjScript.locked) {

                    //Check to see if we have the object needed to water
                    //Search inventory for the item needed - if found water object
                    if (inventory.FindItem(currentInterObjScript.itemNeeded)) {
                        //We found the item needed
                        currentInterObjScript.locked = false;
                        Debug.Log(currentInterObj.name + " was watered");
                    } else {
                        Debug.Log(currentInterObj.name + " was not watered");
                    }
                } else {
                    //object is not locked and we want to water the object
                    Debug.Log(currentInterObj.name + " is watered");
                    currentInterObjScript.Water();
                }
            }
        }  
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       if(other.CompareTag ("interObject")) {
            Debug.Log(other.name);
            currentInterObj = other.gameObject;
            currentInterObjScript = currentInterObj.GetComponent<InteractionObject>();
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("interObject")) {
            if (other.gameObject == currentInterObj) {
                currentInterObj = null;
            }
            
        }
    }
}
