﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SceneManagement;

public class GoogleLogin : MonoBehaviour {

    private const float FontSizeMult = 0.05f;
    private bool mWaitingForAuth = false;
    private string mStatusText = "Ready.";
    private const string LeaderboardID = "CgkIqvO5zaACEAIQAQ";

    // Use this for initialization
    void Start ()
    {
        GooglePlayGames.PlayGamesPlatform.Activate();
        SignIn();
    }

    public void SignIn()
    {
        GooglePlayGames.PlayGamesPlatform.Instance.Authenticate((bool success) =>
        {
            mWaitingForAuth = false;
            if (success)
            {
                // to do ...
                // 로그인 성공 처리
              mStatusText = "Welcome " + Social.localUser.userName;
              //SceneManager.LoadScene("StartUI");


            }
            else
            {
                // to do ...
                // 로그인 실패 처리
                mStatusText = "Authentication failed.";
            }
        });
    }

    public void SignOut()
    {
        GooglePlayGames.PlayGamesPlatform.Instance.SignOut();   
    }

    public void ReportScore(int score)
    {
        GooglePlayGames.PlayGamesPlatform.Instance.ReportScore(score, LeaderboardID, (bool success) =>
        {
            if (success)
            {
                // Report 성공
                // 그에 따른 처리
            }
            else
            {
                // Report 실패
                // 그에 따른 처리
            }
        });
    }

    public void ShowLeaderboardUI()
    {
        // Sign In 이 되어있지 않은 상태라면
        // Sign In 후 리더보드 UI 표시 요청할 것
        if (Social.localUser.authenticated == false)
        {
            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    // Sign In 성공
                    // 바로 리더보드 UI 표시 요청
                    Social.ShowLeaderboardUI();
                    return;
                }
                else
                {
                    // Sign In 실패 
                    // 그에 따른 처리
                    return;
                }
            });
        }
        GooglePlayGames.PlayGamesPlatform.Instance.ShowLeaderboardUI();

    }


    

}