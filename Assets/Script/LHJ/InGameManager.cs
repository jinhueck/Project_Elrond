using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{




    public static InGameManager instance;

    public float playtime;

    public UI_EndGame endgame;
    public UI_GameScore lastscore;
    public UI_StartGame startgame;
    public UI_ComboScale comboview;

    public int totalscore;
    public FirebaseCloud FC;

    ////////////////
    [SerializeField] int jewelry;

    //콤보 피버 점수 관련
    Coroutine ComboCor;
    int plusScore;
    public int combo;
    float combotime;
    bool fevercheck;
    float fevertime;
    int fevercount;

    bool trueadv;
    public int advview;
    [SerializeField] bool forTouch;
    bool startcount;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        SetupGame();

    }

    void Start()
    {

    }

    void Update()
    {
        GameTime();
    }

    void SetupGame()
    {
        plusScore = 100;
        combo = 1;
        totalscore = 0;
        combotime = 3f;
        fevercheck = false;
        fevertime = 5f;
        fevercount = 0;

        jewelry = 0;

        trueadv = false;
        advview = 0;
        startcount =false;

        Sound_Script.instance.Play_MainSound();
    }

    public bool CheckFever()
    {
        return fevercheck;
    }

    public bool TouchCheck
    {
        get
        {
            return forTouch;
        }
        set
        {
            forTouch = value;
        }
    }

    public void AddCombo()
    {
        combo++;

        if (fevercheck == false)
            fevercount++;

        JoinFever();
        combotime -= 0.2f;

        if (combotime <= 0.7f)
            combotime = 0.7f;

        // InGame_UI_Manager.instance.ComboUI(combo);
        comboview.Open_Menu();
        ResetCoroutine();
    }

    private void ResetCoroutine()
    {
        if (ComboCor != null)
            StopCoroutine(ComboCor);
        ComboCor = StartCoroutine(limitCombotime());
    }

    public void ResetCombo()
    {
        combo = 1;
        combotime = 5f;
        //InGame_UI_Manager.instance.ComboUI(combo);
        comboview.Close();
        ResetCoroutine();
    }

    IEnumerator limitCombotime()
    {
        yield return new WaitForSeconds(combotime);
        ResetCombo();
    }

    void JoinFever()
    {
        if (fevercount >= 9)
        {
            StartCoroutine("Fever");
        }
    }

    IEnumerator Fever()
    {
        Debug.Log("Fever Start!!!");
        fevercheck = true;
        fevercount = 0;
        InGame_UI_Manager.instance.Fever.gameObject.SetActive(true);
        Map_Group_Script.instance.Fever_Start();
        yield return new WaitForSeconds(fevertime);

        Debug.Log("Fever END!!!");
        InGame_UI_Manager.instance.Fever.gameObject.SetActive(false);
        fevercheck = false;
        Map_Group_Script.instance.Fever_End();
    }

    public void AddScore()
    {
        if (fevercheck == true)
        {
            totalscore += plusScore * combo * 5;
        }
        else
            totalscore += plusScore * combo;

        InGame_UI_Manager.instance.ScoreUI(totalscore);
    }

    public void Jewelry()
    {
        jewelry++;
    }

    void GameTime()
    {

        if (startcount == false)
        {
            startgame.Open_Menu();
            startcount = true;
        }
        else
        {
            if (playtime > 0)
            {
                playtime -= Time.deltaTime;
                InGame_UI_Manager.instance.TimerUI(playtime);
            }
            else
            {
                if (trueadv == false)
                {
                    trueadv = true;
                    playtime = 0f;
                    Time.timeScale = 0;
                    endgame.OpenEndGame();
                }
                else if (advview == 1)
                {
                    lastscore.Open_Menu();
                    advview++;
                }
            }
        }
    }


    public void EndScore()
    {
        Debug.Log("EndScore 진입");
        Debug.Log("total score : "+totalscore);
        //FC.TopScore = totalscore;

        if (totalscore > FC.TopScore)
        {
            Debug.Log("EndScore 비교");
            FC.TopScore = totalscore;
            Debug.Log("EndScore 비교끝");
        }
        FC.AddScoreToLeaderboard(GPGSIds.leaderboard_score, totalscore);
    }
}