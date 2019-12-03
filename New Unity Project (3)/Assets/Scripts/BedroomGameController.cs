using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BedroomGameController : GameController
{
    public GameObject Monster;
    public GameObject PottedPlant;
    public GameObject GlassOfWater;

    public Text tutorialText; 

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        timerStart = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        //check if inventory added a new item to progress the scene
        if (Inventory.newItem)
        {
            Inventory.newItem = false;
            if(Inventory.FindItem(Ball))
            {
                Inventory.RemoveItem(Ball);
                StartCoroutine(FadeTextToZeroAlpha(2.5f, tutorialText));
                PottedPlant.GetComponent<PottedPlant>().isCurrentlyInteractive = true;
                GlassOfWater.GetComponent<GlassOfWater>().isCurrentlyInteractive = true;
                timerStart = true;
                Monster.GetComponent<Monster>().StartAnim();
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
