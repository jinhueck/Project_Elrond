using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_EndGame : UI_Open

{
    float advtime;
    float timer;
    float gameovertime;

    public Text Timer;
    public Image Clock;

    public UI_GameScore EndScore;

    bool advertisement;//광고의 확인
    
    public uTools.TweenScale timertween;
 
    void Start()
    {
        timer = 10.5f;
        gameovertime = 3f;
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
        InGameManager.instance.playtime += 10f;
        Close_Menu();
        Time.timeScale = 1f; 
    }

    public void EndthisGame()
    {
        InGameManager.instance.EndScore();
        Close_Menu();
        SceneManager.LoadScene("StartUI");
        Time.timeScale = 1f;
    }

    void GameOverTIme()
    {
        if (timer > 0)
        {
            timer -= Time.unscaledDeltaTime;
            Timer.text = string.Format("{0:N0}", timer);
            Clock.fillAmount = timer / 10;
        }
        else
        {
            Close_Menu();
            EndScore.Open_Menu();
            Time.timeScale = 1f;
        }     
    }
}
