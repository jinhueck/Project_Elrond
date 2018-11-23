using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Script : MonoBehaviour {

    public static Sound_Script instance;
    public AudioSource music_Main;
    public AudioSource music_Effect;

    public AudioClip bgm_Main;
    public AudioClip[] bgm_Effect_POP;
    public AudioClip bgm_Effect_Hit;

    private void Awake()
    {
        Setup();
    }

    public void Setup()
    {
        if (Sound_Script.instance == null)
            Sound_Script.instance = this;
    }

    public void Play_EffectPopSound()
    {
        int i = Random.Range(0, bgm_Effect_POP.Length);
        music_Effect.clip = bgm_Effect_POP[i];
        music_Effect.Play();
    }

    public void Play_EffectHitSound()
    {
        int i = Random.Range(0, bgm_Effect_POP.Length);
        music_Effect.clip = bgm_Effect_POP[i];
        music_Effect.Play();
    }

    public void Play_MainSound()
    {
        music_Main.clip = bgm_Main;
        music_Main.Play();
    }
}
