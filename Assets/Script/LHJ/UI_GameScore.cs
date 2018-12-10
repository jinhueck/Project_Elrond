using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UI_GameScore : UI_Open

{
    public uTools.TweenText Score;

    void Start ()
    {
        Sound_Script.instance.ScoreEffectSound();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Scoreview();

    }

    public void EndthisGame()
    {
        InGameManager.instance.EndScore();
        InGame_UI_Manager.instance.UI_Fade.FadeIn(OpenMainScene);
    }

    public void OpenMainScene()
    {
        GameBase_Manager.instance.OpenMainScene();
    }

    public void Scoreview()
    {
        Score.to = InGameManager.instance.totalscore;
    }
}
