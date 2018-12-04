using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delegate_Script : MonoBehaviour {

    public AnimationCurve curve_Open_pos;
    public AnimationCurve curve_Close_pos;

    public AnimationCurve curve_Open_size;
    public AnimationCurve curve_Close_size;
    public float AnimationSpeed;
    float timer;

    Coroutine coroutine;

    public delegate void Delegate_Action();
    delegate void Delegate_Size(float time);

    Vector3 nowScale;
    Vector3 nowPos;

    GameObject obj_target;

    public void SetTarget(GameObject _obj)
    {
        obj_target = _obj;
        nowScale = obj_target.transform.localScale;
        nowPos = obj_target.transform.position;
    }

    void SetCoroutine()
    {
        if (coroutine != null)
            StopCoroutine(coroutine);
    }

    public void Scale_Open(Delegate_Action delegate_Action = null)
    {
        SetCoroutine();
        if (delegate_Action == null)
            coroutine = StartCoroutine(Cor_Action(UI_Open, ActiveTrue));
        else
            coroutine = StartCoroutine(Cor_Action(UI_Open, delegate_Action));
    } 
    public void Scale_Close(Delegate_Action delegate_Action = null)
    {
        SetCoroutine();
        if (delegate_Action == null)
            coroutine = StartCoroutine(Cor_Action(UI_Close, ActiveFalse));
        else
            coroutine = StartCoroutine(Cor_Action(UI_Close, delegate_Action));
    }
    public void Move_Open(Delegate_Action delegate_Action = null)
    {
        SetCoroutine();
        if (delegate_Action == null)
            coroutine = StartCoroutine(Cor_Action(UI_Move_Open, ActiveTrue));
        else
            coroutine = StartCoroutine(Cor_Action(UI_Move_Open, delegate_Action));
    }
    public void Move_Close(Delegate_Action delegate_Action = null)
    {
        SetCoroutine();
        if (delegate_Action == null)
            coroutine = StartCoroutine(Cor_Action(UI_Move_Close, ActiveFalse));
        else
            coroutine = StartCoroutine(Cor_Action(UI_Move_Close, delegate_Action));
    }

    IEnumerator Cor_Action(Delegate_Size delegate_Size, Delegate_Action delegate_Action)
    {
        timer = 0;
        float time_del = AnimationSpeed;
        float time_check = AnimationSpeed;
        while (time_check >= 0.0f)
        {
            time_check -= Time.deltaTime;
            delegate_Size(time_del);
            yield return null;
        }
        delegate_Action();
    }
    void UI_Open(float time)
    {
        timer += Time.deltaTime / time;

        float y = curve_Open_size.Evaluate(timer);
        obj_target.transform.localScale = nowScale * y;
    }
    void UI_Close(float time)
    {
        timer += Time.deltaTime / time;

        float y = curve_Close_size.Evaluate(timer);
        obj_target.transform.localScale = nowScale * y;
    }

    void ActiveFalse()
    {
        obj_target.SetActive(false);
    }
    void ActiveTrue()
    {
        obj_target.SetActive(true);
    }

    void UI_Move_Open(float time)
    {
        timer += Time.deltaTime / time;

        float y = curve_Open_pos.Evaluate(timer);
        obj_target.transform.position = new Vector3(nowPos.x, nowPos.y * y, nowPos.x);
    }
    void UI_Move_Close(float time)
    {
        timer += Time.deltaTime / time;

        float y = curve_Close_pos.Evaluate(timer);
        obj_target.transform.position = new Vector3(nowPos.x, nowPos.y * y, nowPos.x);
    }
}
