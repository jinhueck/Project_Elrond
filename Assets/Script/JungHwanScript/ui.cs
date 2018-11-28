using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ui : MonoBehaviour {

    public Text TopScore;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameStart()
    {
        SceneManager.LoadScene("JungHwan");
    }

    void PrintTopScore()
    {
        long topscore = GoogleLogin.Instance.TopScore;
        TopScore.text = "TopScore : " + topscore;
    }
}
