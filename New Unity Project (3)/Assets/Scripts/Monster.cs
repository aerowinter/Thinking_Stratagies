using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Interactives
{
  public Animator Anim;
    // Start is called before the first frame update
    protected override void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (Inventory.FindItemByName("Glass_Of_Water"))
        {
            Anim.SetBool("taken", true);
        }
    }
}
