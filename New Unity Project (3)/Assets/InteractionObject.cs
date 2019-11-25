using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    public bool inventory;   //If true this object can be stored in inventory
    public bool openable;    //If true this object can be opened
    public bool waterable;   //If true this object can be watered
    public bool locked;      //If true then object is locked
    public GameObject itemNeeded;   //Item needed in order to interact with this item

    public Animator anim;

  public void DoInteraction()
    {
        //picked up and put in inventory
        gameObject.SetActive(false);
    }

    public void Open()
    {
        anim.SetBool("open", true);
    }

    public void Water()
    {
        anim.SetBool("water", true);
    }

}
