﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{




    public static InGameManager instance;

    public float playtime;

    public UI_EndGame endgame;
    public UI_GameScore lastscore;

    public int totalscore;

    ////////////////
    [SerializeField]int jewelry;

    //콤보 피버 점수 관련
    Coroutine ComboCor;
    int plusScore;
    int combo;
    float combotime;
    bool fevercheck;
    float fevertime;
    int fevercount;

    bool trueadv;
    public int advview;

   
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
        fevertime = 2f;
        fevercount = 0;

        jewelry = 0;

        trueadv = false;
        advview = 0;

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

        InGame_UI_Manager.instance.ComboUI(combo);
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
        InGame_UI_Manager.instance.ComboUI(combo);
        ResetCoroutine();
    }

    IEnumerator limitCombotime()
    {
        yield return new WaitForSeconds(combotime);
        ResetCombo();
    }

    void JoinFever()
    {
        if (fevercount >= 10)
        {
            StartCoroutine("Fever");
        }
    }

    IEnumerator Fever()
    {
        Debug.Log("Fever Start!!!");
        fevercheck = true;
        yield return new WaitForSeconds(fevertime);

        Debug.Log("Fever END!!!");
        fevercount = 0;
        fevercheck = false;
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
        if (playtime > 0)
        {
            playtime -= Time.deltaTime;
            InGame_UI_Manager.instance.TimerUI(playtime);
        }
        else
        {
            if (trueadv == false)
            {
                trueadv=true;
                playtime = 0f;
                Time.timeScale = 0;
                endgame.OpenEndGame();
            }
            else if(advview==1)
            {
                lastscore.Open_Menu();
                advview++;
            }
        }

    }



    public void EndScore()
    {
        Debug.Log("EndScore 진입");
        long score = GoogleLogin.Instance.TopScore;
        if (score < totalscore)
        {
            Debug.Log("EndScore 비교");
            GoogleLogin.Instance.TopScore = totalscore;
            SaveScore();
            Debug.Log("EndScore 비교끝");
        }
        
    }

    void GameEnd()
    {

    }

    
    public void LoadScore() // 구글 클라우드에서 스코어 불러오기
    {
        Debug.Log("LoadScore 진입");
        PlayCloudDataManager.Instance.LoadFromCloud((string dataToLoad) =>
        { GoogleLogin.Instance.TopScore = long.Parse(dataToLoad); });
        Debug.Log("LoadScore 끝");
    }
    

    public void SaveScore() // 구글 클라우드에 스코어 저장
    {
        Debug.Log("SaveScore 진입");
        PlayCloudDataManager.Instance.SaveToCloud(GoogleLogin.Instance.TopScore.ToString());
        Debug.Log("SaveScore 끝");
    }

}