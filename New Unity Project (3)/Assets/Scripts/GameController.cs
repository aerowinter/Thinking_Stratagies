using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Player;
    public GameObject Ball;

    public PointAndClick2DUserControl PlayerScript;

    public Text timerText;
    public bool timerStart;
    public float timer;

    protected virtual void Start()
    {
        timer = 30.0f;
        PlayerScript = Player.GetComponent<PointAndClick2DUserControl>();
        PlayerScript.lastInteractedObject = null;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (timerStart && timer > 0)
        {
            timer -= Time.deltaTime;
            TimeSpan timeLeft = TimeSpan.FromSeconds(timer);
            timerText.text = timeLeft.ToString("ss':'fff");
        }
        if (timerStart && timer < 0)
        {
            //GAME OVER sequence
            timerStart = false;
            timer = -5.0f;
            timerText.text = "Game Over";
            StartCoroutine(FadeTextToZeroAlpha(2.5f, timerText));
            Debug.Log("Game Over");
            GameOver();
        }
    }

    protected IEnumerator FadeTextToZeroAlpha(float time, Text txt)
    {
        txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, 1);
        while (txt.color.a > 0.0f)
        {
            txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, (txt.color.a - (Time.deltaTime / time)));
            yield return null;
        }
    }

    protected void GameOver()
    {
        SpriteRenderer[] spriteArr = this.gameObject.GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < spriteArr.Length; i++)
        {
            Debug.Log(spriteArr[i].name);
            spriteArr[i].color = new Color(255, 0, 0);
        }

        PlayerScript.enabled = false;
    }
}
