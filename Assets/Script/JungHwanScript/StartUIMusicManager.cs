using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartUIMusicManager : MonoBehaviour {

    public static StartUIMusicManager instance;
    public AudioSource music_Main;
    public AudioSource music_Effect;

    public AudioClip bgm_Main;
    public AudioClip bgm_Effect_POP;
    public AudioClip bgm_Effect_Hit;

    public AudioClip bgm_Effect_Rubby;

    public GameObject MainBGMIMG;
    public GameObject EffectSoundIMG;

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
            instance = this;
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
        else if (MainBGMOption == 1)
        {
            MainBGMOption = 0;
            MainBGMIMG.GetComponent<Image>().sprite = Resources.Load<Sprite>("JungHwanResources/BGMT");
            Play_MainSound();
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
        else if (EffectSoundOption == 1)
        {
            EffectSoundOption = 0;
            EffectSoundIMG.GetComponent<Image>().sprite = Resources.Load<Sprite>("JungHwanResources/EffectT");
        }
    }

    public void LoadMainBGM()
    {
        if (MainBGMOption == 0)
        {
            MainBGMIMG.GetComponent<Image>().sprite = Resources.Load<Sprite>("JungHwanResources/BGMT");
        }
        else if (MainBGMOption == 1)
        {
            MainBGMIMG.GetComponent<Image>().sprite = Resources.Load<Sprite>("JungHwanResources/BGMF");
        }
    }

    public void LoadEffectSound()
    {
        if (EffectSoundOption == 0)
        {
            EffectSoundIMG.GetComponent<Image>().sprite = Resources.Load<Sprite>("JungHwanResources/EffectT");
        }
        else if (EffectSoundOption == 1)
        {
            EffectSoundIMG.GetComponent<Image>().sprite = Resources.Load<Sprite>("JungHwanResources/EffectF");
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

    public void LoadPlayerOptionSetting2()
    {   
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
}
