using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GooglePlayGames.PlayGamesPlatform.Activate();
        GoogleLogin.Instance.Login();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
