using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour {




    public static InGameManager instance;

   public float playtime ;



    [SerializeField]private int totalscore;
   
    ////////////////


    //콤보 피버 점수 관련
    Coroutine ComboCor;
    int plusScore;
    int combo;
    float combotime;
    bool fevercheck;
    float fevertime;
    int fevercount;




    bool stopgame =false;//인게임 스탑 확인
    bool advertisement;//광고의 확인


    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        SetupGame();
    }

    void Start ()
    {
    }

    void Update ()
    {
        GameTime();
    }

    void SetupGame()
    {
        plusScore = 100;
        combo = 1;
        totalscore = 0;
        combotime = 5f;
        fevercheck=false;
        fevertime = 2f;
        fevercount=0;
    }

   

    public void AddCombo()
    {
        combo++;

        if (fevercheck == false)
        fevercount++;

        JoinFever();
        combotime -= 0.2f;

        if (combotime<=2f)
            combotime = 2f;

        UIManager.instance.ComboUI(combo);
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
        UIManager.instance.ComboUI(combo);
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
        if(fevercheck==true)
        {
            totalscore += plusScore * combo*5;
        }
        else
        totalscore += plusScore * combo;

        UIManager.instance.ScoreUI(totalscore);
    }

    void GameTime()
    {
        if (stopgame == false)
        {
            
            if (playtime>0)
            {
                playtime -= Time.deltaTime;
                UIManager.instance.TimerUI(playtime);
                //Debug.Log(playtime);

            }            
            else
            {
                playtime = 0f;
                Debug.Log("Game end");
               
                //광고 볼지의 여부 함수
            }
        }
        //게임 정지
    }


    void GameEnd()
    {

    }

}
