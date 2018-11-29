using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UI_GameScore : UI_Open

{
	
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void EndthisGame()
    {
        SceneManager.LoadScene("StartUI");
        InGameManager.instance.EndScore();
        Close_Menu();
    }
}
