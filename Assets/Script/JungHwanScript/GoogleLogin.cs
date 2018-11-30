using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.UI;
using System;

public class GoogleLogin : MonoBehaviour {

    //private const float FontSizeMult = 0.05f;
    //private bool mWaitingForAuth = false;
    private string mStatusText = "Ready.";
    private const string LeaderboardID = "CgkIqvO5zaACEAIQAQ";

    static private GoogleLogin instance;

    public Text A;
    public Text B;
    //구글 로그인 인스턴스화

    public static GoogleLogin Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<GoogleLogin>();

                if(instance = null)
                {
                    instance = new GameObject("GoogleLogin").AddComponent<GoogleLogin>();
                }
            }
            return instance;
        }
    }
    

    /*//어웨이크에서 구글 서버에 접속
    void Awake ()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
            .EnableSavedGames().Build();

        PlayGamesPlatform.InitializeInstance(config);

        PlayGamesPlatform.DebugLogEnabled = false;
        PlayGamesPlatform.Activate();
        //SignIn();
    }
    */

    void Start()
    {
        //Login();
        //SignIn();
        //StartLoadScore();
        PrintScore();

    }

    public void Login() // 로그인
    {
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                // to do ...
                // 로그인 성공 처리
                mStatusText = "Welcome " + Social.localUser.userName;
                //SceneManager.LoadScene("StartUI");
                //StartLoadScore();
            }
            else
            {
                Debug.Log("Login Fail");
            }
        });
        //StartLoadScore();
    }
    #region Achievements
    public void Completeachievement_1000() //업적 1000점 달성
    {
        if (!isAuthenticated)
        {
            Login();
            //SignIn();
            return;
        }

        Social.ReportProgress(GPGSIds.achievement_score_1000, 100.0, (bool success) =>
        {
            if (success)
            {
                PlayerPrefs.SetInt("achievement_score_1000", 1);
            }
            if (!success)
            { Debug.Log("Report Fail!"); }
        });
    }

    public void IncrementAcheievement(string id,int stepsToIncrement)
    {
        PlayGamesPlatform.Instance.IncrementAchievement(id, stepsToIncrement, success =>
        { });
    }

    public void ShowAchivementUI() //업적 UI를 키는 함수
    {
        if (!isAuthenticated)
        {
            Login();
            //SignIn();
            return;
        }
        Social.ShowAchievementsUI();
    }

    #endregion /Achievements

    #region Leaderboards

    public void AddScoreToLeaderboard(string leaderboardID, long score)
    {
        Social.ReportScore(score, leaderboardID, success => { }
        );
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
        PlayGamesPlatform.Instance.ShowLeaderboardUI();

    }
    #endregion /Leaderboards
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
            B.text = "로그인상태";
                }
        else
            B.text = "로그인 실패";
    }

    

   

    /*
    public void SignIn() //로그인 하는 함수이지만 지금은 쓰지않음
    {
        PlayGamesPlatform.Instance.Authenticate((bool success) =>
        {
            mWaitingForAuth = false;
            if (success)
            {
                // to do ...
                // 로그인 성공 처리
              mStatusText = "Welcome " + Social.localUser.userName;
                //SceneManager.LoadScene("StartUI");
                StartLoadScore();


            }
            else
            {
                // to do ...
                // 로그인 실패 처리
                mStatusText = "Authentication failed.";
            }
        });
    }
    */

    public void SignOut()//로그아웃
    {
        PlayGamesPlatform.Instance.SignOut();   
    }

    public void ReportScore(int score)
    {
        PlayGamesPlatform.Instance.ReportScore(score, LeaderboardID, (bool success) =>
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

    

    public long TopScore
    {
        get
        {
            if(!PlayerPrefs.HasKey("TopScore"))
            {
                return 0;
            }
            string tmpTopScore = PlayerPrefs.GetString("TopScore");
            return long.Parse(tmpTopScore);
        }
        set
        {
            if(value > 1000 && !PlayerPrefs.HasKey("achievement_1000"))
            {
                Completeachievement_1000();
            }
            PlayerPrefs.SetString("TopScore", value.ToString());
        }
    }

    public void test()
    {
        long a = TopScore;
        TopScore = 3;
    }

    public void PrintScore()
    {
        long a = TopScore;
        //int intval = Convert.ToInt64(a);
        A.text = a.ToString();
    }

    public void StartLoadScore() // 구글 클라우드에서 스코어 불러오기
    {
        PlayCloudDataManager.Instance.LoadFromCloud((string dataToLoad) =>
        { TopScore = long.Parse(dataToLoad); });
    }

}
