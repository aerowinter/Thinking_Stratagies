using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MatchBox : Interactives
{
    public GameObject Player;
    public GameObject Ball;
    public Ball BallScript;

    public bool arrived = false;

    public double speed;

    private const float FLOOR = -2.47f;

    protected override void Start()
    {
        base.Start();
        speed = 1.2f;
        Ball = Inventory.getItemByName("Ball");
        BallScript = Ball.GetComponent<Ball>();
    }

    protected override void Update()
    {
        base.Update();
        //falls to the ground when the ball hits it
        if (BallScript.arrived && transform.position.y != FLOOR)
        {
            speed *= 1.1;
            transform.position = Vector2.MoveTowards(transform.position,
                new Vector2(transform.position.x, FLOOR), (float)speed * Time.deltaTime);
            if (transform.position.y == FLOOR)
                canTake = true;
        }
    }

    protected override void OnGUI()
    {
        base.OnGUI();
        if (viewingGUI)
        {
            if (Inventory.FindItem(Ball))
            {
                if (GUI.Button(new Rect(screenPos.x, screenPos.y - 25, 70, 25), "Throw ball"))
                {
                    clickedOn = false;
                    viewingGUI = false;
                    clickedOnGUI = true;


                    Ball.transform.position = Player.transform.position;
                    Ball.SetActive(true);
                    BallScript.ThrowAt(gameObject);
                    Inventory.RemoveItem(Ball);
                }
            }
        }
    }
}
