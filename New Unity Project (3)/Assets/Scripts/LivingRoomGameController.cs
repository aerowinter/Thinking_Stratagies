using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LivingRoomGameController : GameController
{
    public GameObject Match_Box;

    private const float FLOOR = -2.47f;

    private double speed;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        timerStart = true;

        
        PlayerScript.enabled = false;
        speed = 3;

        Inventory.AddItem(Ball);

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (Player.transform.position.y != FLOOR)
        {
            speed *= 1.1;
            Player.transform.position = Vector2.MoveTowards(Player.transform.position,
                new Vector2(Player.transform.position.x, FLOOR), (float) speed * Time.deltaTime);
        }
        else
            PlayerScript.enabled = true;
    }

    
}
