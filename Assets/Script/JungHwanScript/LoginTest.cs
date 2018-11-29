using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SceneManagement;
//using GooglePlayGames;

public class LoginTest : MonoBehaviour {

    private void Awake()
    {
        GooglePlayGames.PlayGamesPlatform.Activate();
        //GoogleLogin.Instance.Login();
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                // to do ...
                // 로그인 성공 처리
                //mStatusText = "Welcome " + Social.localUser.userName;
                SceneManager.LoadScene("StartUI");
                //StartLoadScore();
            }
            else
            {
                Debug.Log("Login Fail");
            }
        });
    }   
}
