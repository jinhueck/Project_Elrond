using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sound_Script : MonoBehaviour {

    public static Sound_Script instance;
    public AudioSource music_Main;
    public AudioSource music_Effect;
    public AudioSource music_UI;

    public AudioClip bgm_Main;
    public AudioClip bgm_Effect_POP;
    public AudioClip bgm_Effect_Hit;
    public AudioClip bgm_Effect_UI;

    public AudioClip bgm_Effect_Rubby;


    [SerializeField] private string key_IntSelect = "SetTile";
    int intSelected;

    string Option = "0";
    [SerializeField] private int[] soundoption;

    private void Awake()
    {
        Setup();
    }

    public void Setup()
    {
        if (instance == null)
        {
            instance = this;
        }
        intSelected = PlayerPrefs.GetInt(key_IntSelect);
        bgm_Main = (AudioClip)Resources.Load("JinHyeok/Music/Main/" + intSelected);
        bgm_Effect_POP = (AudioClip)Resources.Load("JinHyeok/Music/TouchBubble/" + intSelected);
        bgm_Effect_Hit = (AudioClip)Resources.Load("JinHyeok/Music/TouchTack/" + intSelected);
        bgm_Effect_Rubby = (AudioClip)Resources.Load("JinHyeok/Music/Rubby");
    }

    public void Play_EffectPopSound()
    {
        if (EffectSoundOption == 0)
        {
            music_Effect.clip = bgm_Effect_POP;
            music_Effect.Play();
        }
    }

    public void Play_EffectRubbySound()
    {
        if (EffectSoundOption == 0)
        {
            music_Effect.clip = bgm_Effect_Rubby;
            music_Effect.Play();
        }
    }

    public void Play_EffectHitSound()
    {
        if (EffectSoundOption == 0)
        {
            music_Effect.clip = bgm_Effect_Hit;
            music_Effect.Play();
        }
    }

    public void Play_MainSound()
    {
        if (MainBGMOption == 0)
        {
            music_Main.clip = bgm_Main;
            music_Main.Play();
        }
    }

    public void PlayStartUI()
    {
        music_Main.clip = (AudioClip)Resources.Load("JungHwanResources/BGM/" + 0);
        music_Main.Play();
    }

    public int MainBGMOption
    {
        get
        {
            if (!PlayerPrefs.HasKey("BGMOption"))
            {
                return 0;
            }
            string tmpBGMOption = PlayerPrefs.GetString("BGMOption");
            return int.Parse(tmpBGMOption);
        }
        set
        {
            PlayerPrefs.SetString("BGMOption", value.ToString());
        }
    }

    public int EffectSoundOption
    {
        get
        {
            if (!PlayerPrefs.HasKey("EffectSoundOption"))
            {
                return 0;
            }
            string tmpBGMOption = PlayerPrefs.GetString("EffectSoundOption");
            return int.Parse(tmpBGMOption);
        }
        set
        {
            PlayerPrefs.SetString("EffectSoundOption", value.ToString());
        }
    }

    public void TimerEffectSound()
    {
        music_UI.clip = (AudioClip)Resources.Load("JungHwanResources/EffectBGM/UIBGM/Clock");
        music_UI.Play();
    }

    public void TimerEffectSoundOff()
    {
        music_UI.clip = (AudioClip)Resources.Load("JungHwanResources/EffectBGM/UIBGM/Clock");
        music_UI.Stop();
    }

    public void ScoreEffectSound()
    {
        music_UI.clip = (AudioClip)Resources.Load("JungHwanResources/EffectBGM/UIBGM/FinalScore");
        music_UI.Play();
    }

    public void ClickSound()
    {
        if (EffectSoundOption == 0)
        {
            music_UI.clip = (AudioClip)Resources.Load("JungHwanResources/EffectBGM/UIBGM/ClickSound");
            music_UI.Play();
        }
    }
}
