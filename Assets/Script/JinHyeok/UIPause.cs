using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPause : UI_Open
{

    UnityEngine.Events.UnityAction m_finished;
    public UI_StartGame restart;

    private void Awake()
    {
        tweenScale.onFinished.AddListener(OnTweenFinished);
    }

    void OnTweenFinished()
    {
        if (null != m_finished)
            m_finished();
    }

    public void OnClick_Main()
    {

        Time.timeScale = 1;
        InGame_UI_Manager.instance.UI_Fade.FadeIn(OpenMainScene);
    }

    public void OpenMainScene()
    {
        GameBase_Manager.instance.OpenMainScene();
        Sound_Script.instance.PlayStartUI();
    }

    public void OpenMenu()
    {
        Open_Menu();
        Time.timeScale = 0;
    }


    public void CloseMenu()
    {
        Close_Menu();
        restart.timerreset();   
        restart.Open_Menu();    
        Time.timeScale = 1;
    }
}
