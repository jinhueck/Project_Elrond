using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sound_Script : MonoBehaviour {

    public static Sound_Script instance;
    public AudioSource music_Main;
    public AudioSource music_Effect;

    public AudioClip bgm_Main;
    public AudioClip bgm_Effect_POP;
    public AudioClip bgm_Effect_Hit;

    public AudioClip bgm_Effect_Rubby;

    public GameObject MainBGMIMG;
    public GameObject EffectSoundIMG;

    [SerializeField] private string key_IntSelect = "SetTile";
    int intSelected;

    string Option = "0";
    [SerializeField] private int[] soundoption;

    private void Awake()
    {
        Setup();
        LoadPlayerOptionSetting();
    }

    public void Setup()
    {
        if (instance == null)
        {   
            DontDestroyOnLoad(transform.root.gameObject);
            instance = this;
            intSelected = PlayerPrefs.GetInt(key_IntSelect);
            bgm_Main = (AudioClip)Resources.Load("JinHyeok/Music/Main/" + intSelected);
            bgm_Effect_POP = (AudioClip)Resources.Load("JinHyeok/Music/TouchBubble/" + intSelected);
            bgm_Effect_Hit = (AudioClip)Resources.Load("JinHyeok/Music/TouchTack/" + intSelected);
            bgm_Effect_Rubby = (AudioClip)Resources.Load("JinHyeok/Music/Rubby");
        }
        else
        {
            Destroy(this.gameObject);
        }
        
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

    public void SetMainBGM()
    {
        Debug.Log(MainBGMOption + "브금");
        if (MainBGMOption == 0)
        {
            MainBGMOption = 1;
            MainBGMIMG.GetComponent<Image>().sprite = Resources.Load<Sprite>("JungHwanResources/BGMF");
            music_Main.Stop();
        }
        else if(MainBGMOption == 1)
        {
            MainBGMOption = 0;
            MainBGMIMG.GetComponent<Image>().sprite = Resources.Load<Sprite>("JungHwanResources/BGMT");
            music_Main.Play();
        }
    }

    public void SetEffectSound()
    {
        Debug.Log(EffectSoundOption + "이펙트");
        if (EffectSoundOption == 0)
        {
            EffectSoundOption = 1;
            EffectSoundIMG.GetComponent<Image>().sprite = Resources.Load<Sprite>("JungHwanResources/EffectF");
        }
        else if(EffectSoundOption == 1)
        {
            EffectSoundOption = 0;
            EffectSoundIMG.GetComponent<Image>().sprite = Resources.Load<Sprite>("JungHwanResources/EffectT");
        }
    }

    public void LoadMainBGM()
    {
        if (MainBGMOption == 0)
        {   
            MainBGMIMG.GetComponent<Image>().sprite = Resources.Load<Sprite>("JungHwanResources/BGMF");
        }
        else if (MainBGMOption == 1)
        {
            MainBGMIMG.GetComponent<Image>().sprite = Resources.Load<Sprite>("JungHwanResources/BGMT");
        }
    }

    public void LoadEffectSound()
    {
        if (EffectSoundOption == 0)
        {   
            EffectSoundIMG.GetComponent<Image>().sprite = Resources.Load<Sprite>("JungHwanResources/EffectF");
        }
        else if (EffectSoundOption == 1)
        {
            EffectSoundIMG.GetComponent<Image>().sprite = Resources.Load<Sprite>("JungHwanResources/EffectT");
        }
    }

    public void PlayStartUI()
    {
        music_Main.clip = (AudioClip)Resources.Load("JungHwanResources/BGM/" + 0);
        music_Main.Play();
    }

    public void LoadPlayerOptionSetting()
    {
        if (SceneManager.GetActiveScene().name == "StartUI" && MainBGMOption == 0)
        {
            PlayStartUI();
        }
        LoadMainBGM();
        Debug.Log(MainBGMOption + "브금");
        LoadEffectSound();
        Debug.Log(EffectSoundOption + "이펙트");
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
    /*
    int[] FindOptionSetting()
    {
        int size = 2;
        int[] OptionInfo = new int[size];
        if (PlayerPrefs.GetString(Option) != "")
        {
            string[] option;
            option = PlayerPrefs.GetString(Option).Split(',');
            for (int i = 0; i < OptionInfo.Length; i++)
            {
                OptionInfo[i] = System.Convert.ToInt32(option[i]);
            }
        }
        else
        {
            string value = OptionInfo[0].ToString();
            for(int i = 1; i<size; i++)
            {
                value += "," + OptionInfo[i];
            }
            PlayerPrefs.SetString(Option, value);
        }
        
        return OptionInfo;
    }

    public void SetUserSoundOption(int num)
    {
        soundoption[num] = 1;

        string value = soundoption[0].ToString();
        for(int i = 1; i<soundoption.Length; i++)
        {
            value += "," + soundoption[i];
        }
        PlayerPrefs.SetString(Option, value);
    }
    */


}
