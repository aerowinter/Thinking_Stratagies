using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Inventory
{
    //array that hold all our items
    static public GameObject[] inventory = new GameObject[10];

    static public void AddItem(GameObject item ){

        bool itemAdded = false;

        //find the first open slot in inventory
        for (int i = 0; i < inventory.Length; i++) {
            if(inventory[i] == null) {
                inventory[i] = item;
                Debug.Log(item.name + " was added");
                itemAdded = true;
                //do something with object
                item.SendMessage("DoInteraction");
                break;
            }
        }

        //Inventory full
        if (!itemAdded) {
            Debug.Log("Inventory is full - item not added");
        }
    }

    static public bool FindItem(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++) {
            if(inventory[i] == item) {
                //we found item
                return true;
            }
        }
        //item not found
        return false;
    }

    static public bool FindItemByName(string gameObjectName)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] != null && inventory[i].name == gameObjectName)
            {
                Debug.Log(inventory[i].name);
                //we found item
                return true;
            }
        }
        //item not found
        return false;
    }
}
