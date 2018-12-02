using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;
using GooglePlayGames.BasicApi.SavedGame;
using System;
using GooglePlayGames.BasicApi;

public class FirebaseCloud : MonoBehaviour {

    public Text A;
    public Text t_GPGSDebugtext;

    private void Start()
    {
        PrintScore();
    }

    public void showLeaderboardUI()
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
        //PlayGamesPlatform.Instance.ShowLeaderboardUI();
        //((PlayGamesPlatform)Social.Active).
        Social.ShowLeaderboardUI();
    }

    public void SubmitToLeaderBoard(int score) //리더보드 점수 등록
    {
        score = TopScore;
        if(PlayGamesPlatform.Instance.localUser.authenticated)
        {
            Social.ReportScore(1000, GPGSIds.leaderboard_score, (bool success) =>
            {
                if(success)
                {
                    LogGPGS("Update Score Success");
                }
                else
                {
                    LogGPGS("Update Score Fail");
                }
            });
        }
        else
        {
            LogGPGS("Need Log in");
        }
    }

    public void PrintTokens() //토큰 출력
    {
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            //유저 토큰 받기 첫번째 방법
            //string _IDtoken = PlayGamesPlatform.Instance.GetIdToken();
            //두번째 방법
            string _IDtoken = ((PlayGamesLocalUser)Social.localUser).GetIdToken();

            //인증코드 받기
            string _authCode = PlayGamesPlatform.Instance.GetServerAuthCode();
            LogGPGS("authcode : " + _authCode + " / " + "idtoken : " + _IDtoken);
        }
        else
        {
            LogGPGS("접속되어있지 않습니다. PlayGamesPlatform.Instance.localUser.authenticated :  fail");
        }
    }

    public void SignOut()//로그아웃
    {
        PlayGamesPlatform.Instance.SignOut();
    }

    public void LogGPGS(string _log)
    {
        Debug.Log(_log);
        t_GPGSDebugtext.text = _log;
    }

    public void PrintScore() //점수 출력
    {
        if (A != null)
        {
            int s = TopScore;
            //int a = InGameManager.instance.EndScore();
            A.text = s.ToString();
        }
    }

    public int TopScore
    {
        get
        {
            if (!PlayerPrefs.HasKey("TopScore"))
            {
                return 0;
            }
            string tmpTopScore = PlayerPrefs.GetString("TopScore");
            return int.Parse(tmpTopScore);
        }
        set
        {
            if (value > 1000 && !PlayerPrefs.HasKey("achievement_1000"))
            {
                //Completeachievement_1000();
            }
            PlayerPrefs.SetString("TopScore", value.ToString());
        }
    }

    public void ResetScore()
    {
        TopScore = 0;
        PrintScore();
    }

    public bool isAuthenticated //현재 로그인이 되어있는지 확인하는 함수
    {
        get
        {
            return Social.localUser.authenticated;
        }
    }

    public void iflogin()
    {
        bool a = isAuthenticated;
        if (a == true)
        {
            t_GPGSDebugtext.text = "로그인상태";
        }
        else
            t_GPGSDebugtext.text = "로그인 실패";
    }

    public void AddScoreToLeaderboard(string leaderboardID, int score)
    {
        Social.ReportScore(score, leaderboardID, success => { }
        );
    }

    public void LoadScore() // 구글 클라우드에서 스코어 불러오기
    {
        Debug.Log("LoadScore 진입");
        PlayCloudDataManager.Instance.LoadFromCloud((string dataToLoad) =>
        { TopScore = int.Parse(dataToLoad); });
        PrintScore();
        LogGPGS("불러오기완료");
        Debug.Log("LoadScore 끝");
    }


    public void SaveScore() // 구글 클라우드에 스코어 저장
    {
        Debug.Log("SaveScore 진입");
        PlayCloudDataManager.Instance.SaveToCloud(TopScore.ToString());
        Debug.Log("SaveScore 끝");
        LogGPGS("저장완료");
    }

}
