using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Script : MonoBehaviour {

    public static Sound_Script instance;
    public AudioSource music_Main;
    public AudioSource music_Effect;

    public AudioClip bgm_Main;
    public AudioClip bgm_Effect_POP;
    public AudioClip bgm_Effect_Hit;

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
    }

    public void Play_EffectPopSound()
    {
        music_Effect.clip = bgm_Effect_POP;
        music_Effect.Play();
    }

    public void Play_EffectHitSound()
    {
        music_Effect.clip = bgm_Effect_Hit;
        music_Effect.Play();
    }

    public void Play_MainSound()
    {
        music_Main.clip = bgm_Main;
        music_Main.Play();
    }
}
