using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyMove : MonoBehaviour {

    private Vector3 StartPosition;
    private Vector3 zeroPosition = new Vector3(0, 0, 0);
    private float startTime;
    public float speed;
    Coroutine cor;

    public void MoveRuby(Vector3 vec)
    {
        //if (cor != null)
        //StopCoroutine(cor);
        //this.gameObject.SetActive(true);
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
            Debug.Log("루비이동중");
            currPosition = transform.position;
            float step = speed * (Time.time - startTime);
            transform.position = Vector3.MoveTowards(currPosition, StartPosition, step);
            startTime = Time.time;

            yield return null;
        }
        this.gameObject.SetActive(false);
        //this.transform.position = zeroPosition;
        RubyMaker.instance.PushToPool(RubyMaker.instance.RubyIMGList, this.gameObject);
        Debug.Log("루비 코루틴 끝");
        yield break;
    }
}
