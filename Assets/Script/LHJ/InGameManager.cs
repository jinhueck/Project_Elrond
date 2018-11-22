using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour {




    public static InGameManager instance=null;








    private float playtime = 60f;



    private int totalscore;
   
    ////////////////


    //콤보 피버 점수 관련
    Coroutine ComboCor;
    int plusScore=100;
    int combo=1;
    float combotime=5f;
    bool fevercheck;
    float fevertime = 2f;
    int fevercount;




    bool stopgame =false;//인게임 스탑 확인
    bool advertisement;//광고의 확인


    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }

        totalscore = 0;
    }

    void Start ()
    {
    }

    void Update ()
    {
        GameTime();
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
        fevercheck = true;
        yield return new WaitForSeconds(fevertime);
        fevercount = 0;
        fevercheck = false;
    }

    public void ScoreManager()
    {
        if(fevercheck==true)
        {
            totalscore += plusScore * combo*5;
        }
        else
        totalscore += plusScore * combo;
    }

    void GameTime()
    {
        if (stopgame == false)
        {
            
            if (playtime>0)
            {
                playtime -= Time.deltaTime;
                //Debug.Log(playtime);
                
            }            
            else
            {
                playtime = 0f;
                Debug.Log("Game end");
                //게임 정지
                //광고 볼지의 여부 함수
            }
        }
    }

    
    void GameEnd()
    {

    }

}
