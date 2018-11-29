using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_EndGame : UI_Open

{
    float advtime;

    bool advertisement;//광고의 확인

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
        SceneManager.LoadScene("StartUI");
        InGameManager.instance.EndScore();
        Close_Menu();
        Time.timeScale = 1f;
    }
}
