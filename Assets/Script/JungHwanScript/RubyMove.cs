using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyMove : MonoBehaviour {

    public static RubyMove instance;
    private Vector3 StartPosition;
    private float startTime;
    public float speed;

    Coroutine cor;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void MoveRuby(Vector3 vec)
    {
        //if (cor != null)
            //StopCoroutine(cor);
        cor = StartCoroutine(MoveTopRuby(vec));
    }

    IEnumerator MoveTopRuby(Vector3 vec)
    {
        //Debug.Log("GoBackStage 코루틴 진입");
        StartPosition = vec;

        Vector3 currPosition;

        startTime = Time.time;
        Map_Group_Script.instance.check = true;
        while (transform.position != StartPosition)
        {
            currPosition = transform.position;
            float step = speed * (Time.time - startTime);
            transform.position = Vector3.MoveTowards(currPosition, StartPosition, step);
            startTime = Time.time;

            yield return null;
        }
        this.gameObject.SetActive(false);
        Debug.Log("루비 코루틴 끝");
        yield break;
    }
}
