using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class LivingRoomGameController : MonoBehaviour
{
    public GameObject Player;
    public PointAndClick2DUserControl PlayerScript;

    private const float PLAYER_Y = -2.47f;

    private double speed;

    // Start is called before the first frame update
    void Start()
    {
        PlayerScript = Player.GetComponent<PointAndClick2DUserControl>();
        PlayerScript.enabled = false;
        speed = 3;

    }

    // Update is called once per frame
    void Update()
    {

        if (Player.transform.position.y != PLAYER_Y)
        {
            speed *= 1.1;
            Player.transform.position = Vector2.MoveTowards(Player.transform.position,
                new Vector2(Player.transform.position.x, PLAYER_Y), (float) speed * Time.deltaTime);
        }
        else
            PlayerScript.enabled = true;
    }
}
