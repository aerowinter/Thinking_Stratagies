using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BedroomGameController : MonoBehaviour
{
    public GameObject Player;
    public GameObject PottedPlant;
    public GameObject GlassOfWater;
    public GameObject Ball;

    public Text tutorialText;

    public Text timerText;
    public bool timerStart = false;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 30.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStart)
        {
            timer -= Time.deltaTime;
            TimeSpan timeLeft = TimeSpan.FromSeconds(timer);
            timerText.text = timeLeft.ToString("ss':'fff");
        }

        if (timer < 0)
            //GAME OVER sequence
            Debug.Log("Game Over");

        //check if inventory added a new item to progress the scene
        if (Inventory.newItem)
        {
            Inventory.newItem = false;
            if(Inventory.FindItem(Ball) && tutorialText.color.a != 0)
            {
                StartCoroutine(FadeTextToZeroAlpha(2.5f, tutorialText));
                PottedPlant.GetComponent<PottedPlant>().isCurrentlyInteractive = true;
                GlassOfWater.GetComponent<GlassOfWater>().isCurrentlyInteractive = true;
                timerStart = true;
            }
        }


        IEnumerator FadeTextToZeroAlpha(float time, Text txt)
        {
            txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, 1);
            while (txt.color.a > 0.0f)
            {
                txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, (txt.color.a - (Time.deltaTime / time)));
                yield return null;
            }
        }

    }
}
