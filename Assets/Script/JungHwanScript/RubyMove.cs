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
        cor = StartCoroutine(MoveTopRuby(vec));
    }

    IEnumerator MoveTopRuby(Vector3 vec)
    {
        StartPosition = vec;
        Vector3 currPosition;
        startTime = Time.time;

        while (transform.position != StartPosition)
        {
            currPosition = transform.position;
            float step = speed * (Time.time - startTime);
            transform.position = Vector3.MoveTowards(currPosition, StartPosition, step);
            startTime = Time.time;

            yield return null;
        }
        this.gameObject.SetActive(false);
        RubyMaker.instance.PushToPool(RubyMaker.instance.RubyIMGList, this.gameObject);
        yield break;
    }
}
