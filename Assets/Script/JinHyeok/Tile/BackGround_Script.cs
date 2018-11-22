using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_Script : MonoBehaviour {
    public static BackGround_Script instance;
    [SerializeField] private GameObject backGround;
    [SerializeField] private GameObject backGroundFever;
    private Coroutine coroutine;

    private void Awake()
    {
        Setup();
    }

    public void Setup()
    {
        if (BackGround_Script.instance == null)
            BackGround_Script.instance = this;
    }

    public void Attacked()
    {
        if (coroutine != null)
            StopCoroutine(coroutine);
        coroutine = StartCoroutine(BackGroundChange());
    }
    private IEnumerator BackGroundChange()
    {
        backGround.SetActive(true);
        yield return new WaitForSeconds(0.01f);
        backGround.SetActive(false);
    }


    public void Fevered()
    {

    }
    private IEnumerator FeverChange()
    {
        backGround.SetActive(true);
        yield return new WaitForSeconds(5f);
        backGround.SetActive(false);
    }
}
