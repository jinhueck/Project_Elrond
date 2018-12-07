using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_StartGame : UI_Open
{

    public float timer;

    public Text starttimer;

    private void Awake()
    {
        timerreset();
    }
	
	// Update is called once per frame
	void Update ()
    {
        StartCount();
    }

    public void StartCount()
    {
        Time.timeScale = 0;
        if (timer > -0.5f)
        {
            timer -= Time.unscaledDeltaTime;
            starttimer.text = string.Format("{0:N0}", timer); 

            if(timer<0.7f)
            {
                this.tweenScale.from = new Vector3(1, 1, 1);
                starttimer.text = "Start Game";
            }
        }   
        else
        {
            
            this.Close_Menu();
            Time.timeScale = 1;
        }
    }

    public void timerreset()
    {
        timer = 3.5f; 
    }

}
