using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Ball : Interactives
{
    public Vector2 target;
    public bool thrown = false;
    public bool arrived = false;

    protected override void Start()
    {
        base.Start();
        canTake = true;
        target = transform.position;
    }

    protected override void Update()
    {
        base.Update();
        if (thrown)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, (4.5f / Time.deltaTime));
            if ((Vector2) transform.position == target)
            {
                arrived = true;
                thrown = false;
            }
        }
    }

    public void ThrowAt(GameObject gamObj)
    {
        target = gamObj.transform.position;
        thrown = true;
        canTake = false;
    }
}
