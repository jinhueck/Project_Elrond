using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_EndGame : UI_Open

{
    float advtime;
    float timer;


    public Text Timer;
    public Image Clock;

    public UI_GameScore EndScore;
    public UnityAdsHelper adver;

    bool advertisement;//광고의 확인
    
    public uTools.TweenScale timertween;
 
    void Start()
    {
        timer = 10.5f;
        Sound_Script.instance.TimerEffectSound();
    }

    
    // Update is called once per frame
    void Update()
    {
        GameOverTIme();
    }

    public void OpenEndGame()
    {
        Open_Menu();
        Time.timeScale = 0f;
    }


   public void Advertisingrh()
    {
        Sound_Script.instance.TimerEffectSoundOff();
        adver.ShowRewardedAd();
        Close_Menu();
    }

    public void EndthisGame()
    {
        Sound_Script.instance.TimerEffectSoundOff();
        EndScore.Open_Menu();
        Close_Menu();
        Time.timeScale = 1f;
    }

    void GameOverTIme()
    {   
        if (timer > 0)
        {
            timer -= Time.unscaledDeltaTime;
            Clock.fillAmount = timer / 10;
            if (timer > 3.5f)
            {    
                Timer.text = string.Format("{0:N0}", timer); 
            }
            else
            {
                Timer.text =  "<color=#ff0000>" + string.Format("{0:N0}", timer) + "</color>";
            }
        }
        else
        {
            Close_Menu();
            EndScore.Open_Menu();
            Time.timeScale = 1f;
        }     
    }
}
