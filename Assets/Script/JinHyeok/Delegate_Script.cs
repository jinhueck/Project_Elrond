using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delegate_Script : MonoBehaviour {

    public AnimationCurve curve_Open_pos;
    public AnimationCurve curve_Close_pos;

    public AnimationCurve curve_Open_size;
    public AnimationCurve curve_Close_size;
    public float AnimationSpeed;
    protected float timer;

    protected Coroutine coroutine;

    public delegate void Delegate_Action();
    protected delegate void Delegate_Size(float time);

    protected Vector3 nowScale;
    protected Vector3 nowPos;

    [SerializeField]protected GameObject obj_target;

    public void SetTarget(GameObject _obj)
    {
        obj_target = _obj;
        nowScale = obj_target.transform.localScale;
        nowPos = obj_target.transform.position;
    }

    protected void SetCoroutine()
    {
        if (coroutine != null)
            StopCoroutine(coroutine);
    }

    public void Scale_Open(Delegate_Action delegate_Action = null)
    {
        SetCoroutine();
        if (delegate_Action == null)
            coroutine = StartCoroutine(Cor_Action_Start(UI_Open, ActiveTrue));
        else
            coroutine = StartCoroutine(Cor_Action_Start(UI_Open, delegate_Action));
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
            coroutine = StartCoroutine(Cor_Action_Start(UI_Move_Open, ActiveTrue));
        else
            coroutine = StartCoroutine(Cor_Action_Start(UI_Move_Open, delegate_Action));
    }
    public void Move_Close(Delegate_Action delegate_Action = null)
    {
        SetCoroutine();
        if (delegate_Action == null)
            coroutine = StartCoroutine(Cor_Action(UI_Move_Close, ActiveFalse));
        else
            coroutine = StartCoroutine(Cor_Action(UI_Move_Close, delegate_Action));
    }

    protected IEnumerator Cor_Action(Delegate_Size delegate_Size, Delegate_Action delegate_Action)
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
    protected IEnumerator Cor_Action_Start(Delegate_Size delegate_Size, Delegate_Action delegate_Action)
    {
        timer = 0;
        float time_del = AnimationSpeed;
        float time_check = AnimationSpeed;
        delegate_Action();
        while (time_check >= 0.0f)
        {
            time_check -= Time.deltaTime;
            delegate_Size(time_del);
            yield return null;
        }
    }
    protected virtual void UI_Open(float time)
    {
        timer += Time.deltaTime / time;

        float y = curve_Open_size.Evaluate(timer);
        obj_target.GetComponent<RectTransform>().localScale = nowScale * y;
        Debug.Log("obj_target.GetComponent<RectTransform>().localScale : " + obj_target.GetComponent<RectTransform>().localScale);
    }
    protected virtual void UI_Close(float time)
    {
        timer += Time.deltaTime / time;

        float y = curve_Close_size.Evaluate(timer);
        obj_target.transform.localScale = nowScale * y;
    }

    protected void ActiveFalse()
    {
        obj_target.SetActive(false);
    }
    protected void ActiveTrue()
    {
        obj_target.SetActive(true);
    }

    protected virtual void UI_Move_Open(float time)
    {
        timer += Time.deltaTime / time;

        float y = curve_Open_pos.Evaluate(timer);
        obj_target.transform.position = new Vector3(nowPos.x, nowPos.y * y, nowPos.x);
    }
    protected virtual void UI_Move_Close(float time)
    {
        timer += Time.deltaTime / time;

        float y = curve_Close_pos.Evaluate(timer);
        obj_target.transform.position = new Vector3(nowPos.x, nowPos.y * y, nowPos.x);
    }
}
