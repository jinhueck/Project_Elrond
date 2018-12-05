using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UI_GameScore : UI_Open

{
    public uTools.TweenText Score;
    public FirebaseCloud cloud;

    void Start ()
    {
        cloud = GetComponent<FirebaseCloud>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Scoreview();

    }

    public void EndthisGame()
    {
        InGameManager.instance.EndScore();
        Close_Menu();
        GameBase_Manager.instance.OpenMainScene();
    }

    public void Scoreview()
    {
        Score.to = InGameManager.instance.totalscore;
    }
}
