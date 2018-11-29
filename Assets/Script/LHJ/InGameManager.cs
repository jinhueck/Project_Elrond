using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{




    public static InGameManager instance;

    public float playtime;

    public UI_EndGame endgame;

    [SerializeField] private int totalscore;

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

    int trueadv;


   
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

        trueadv = 0;


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
        else if(trueadv == 0)
        {
            playtime = 0f;
            Debug.Log("Game end");
            Time.timeScale = 0;
            endgame.OpenEndGame();
            trueadv++;
        }
        else
        {
            
        }
        //게임 정지
    }



    public void EndScore()
    {
        
        long score = GoogleLogin.Instance.TopScore;
        if (score < totalscore)
        {
            GoogleLogin.Instance.TopScore = totalscore;
            SaveScore();
        }
        
    }

    void GameEnd()
    {

    }

    
    public void LoadScore() // 구글 클라우드에서 스코어 불러오기
    {
        PlayCloudDataManager.Instance.LoadFromCloud((string dataToLoad) =>
        { GoogleLogin.Instance.TopScore = long.Parse(dataToLoad); });
    }
    

    public void SaveScore() // 구글 클라우드에 스코어 저장
    {
        PlayCloudDataManager.Instance.SaveToCloud(GoogleLogin.Instance.TopScore.ToString());
    }

}