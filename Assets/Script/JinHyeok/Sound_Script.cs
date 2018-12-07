using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound_Script : MonoBehaviour {

    public static Sound_Script instance;
    public AudioSource music_Main;
    public AudioSource music_Effect;

    public AudioClip bgm_Main;
    public AudioClip bgm_Effect_POP;
    public AudioClip bgm_Effect_Hit;

    public AudioClip bgm_Effect_Rubby;

    bool Bool_music_Main;
    bool Bool_effect_Bgm;


    [SerializeField] private string key_IntSelect = "SetTile";
    int intSelected;

    private void Awake()
    {
        Setup();
    }

    public void Setup()
    {
        if (Sound_Script.instance == null)
            Sound_Script.instance = this;
        intSelected = PlayerPrefs.GetInt(key_IntSelect);
        bgm_Main = (AudioClip)Resources.Load("JinHyeok/Music/Main/" + intSelected);
        bgm_Effect_POP = (AudioClip)Resources.Load("JinHyeok/Music/TouchBubble/" + intSelected);
        bgm_Effect_Hit = (AudioClip)Resources.Load("JinHyeok/Music/TouchTack/" + intSelected);
        bgm_Effect_Rubby = (AudioClip)Resources.Load("JinHyeok/Music/Rubby");
    }

    public void Play_EffectPopSound()
    {
        if (Bool_effect_Bgm)
        {
            music_Effect.clip = bgm_Effect_POP;
            music_Effect.Play();
        }
    }

    public void Play_EffectRubbySound()
    {
        if (Bool_effect_Bgm)
        {
            music_Effect.clip = bgm_Effect_Rubby;
            music_Effect.Play();
        }
    }

    public void Play_EffectHitSound()
    {
        if (Bool_effect_Bgm)
        {
            music_Effect.clip = bgm_Effect_Hit;
            music_Effect.Play();
        }
    }

    public void Play_MainSound()
    {
        if (Bool_music_Main)
        {
            music_Main.clip = bgm_Main;
            music_Main.Play();
        }
    }

    public void SetMainBGM()
    {
        Sprite obj = GameObject.Find("Rolling_Menu").transform.GetChild(1).GetComponent<Sprite>();
        if (Bool_music_Main)
        {
            Bool_music_Main = false;
            obj = Resources.Load<Sprite>("JungHwanResources/BGMF");
        }
        else
        {
            Bool_music_Main = true;
            obj = Resources.Load<Sprite>("JungHwanResources/BGMT");
        }
    }

    public void SetEffectSound()
    {
        if (Bool_effect_Bgm)
        {
            Bool_effect_Bgm = false;
        }
        else
        {
            Bool_effect_Bgm = true;
        }
    }
}
