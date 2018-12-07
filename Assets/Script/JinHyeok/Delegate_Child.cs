using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delegate_Child : Delegate_Script {

    int checking;

    private void Awake()
    {
        SetTarget(this.gameObject);
    }

    protected override void UI_Open(float time)
    {
        timer += Time.deltaTime / time;

        float y = curve_Open_size.Evaluate(timer);
        obj_target.transform.localScale = new Vector3(nowScale.x, nowScale.y * y, nowScale.z);
    }
    protected override void UI_Close(float time)
    {
        timer += Time.deltaTime / time;

        float y = curve_Close_size.Evaluate(timer);
        obj_target.transform.localScale = new Vector3(nowScale.x, nowScale.y * y, nowScale.z);
    }

    void ResetChild()
    {
        for(int i = 0; i < transform.childCount; i ++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    void OpenChild()
    {
        transform.GetChild(checking).GetComponent<UI_Open>().Open_Menu();
    }
    void CloseChild()
    {
        transform.GetChild(checking).GetComponent<UI_Open>().Close_Menu();
    }

    protected IEnumerator Cor_Action(Delegate_Size delegate_Size, Delegate_Action delegate_Action , Delegate_Action delegate_Between)
    {
        timer = 0;
        float time_del = AnimationSpeed;
        float time_check = AnimationSpeed;

        int count = this.transform.childCount;
        float size = AnimationSpeed / count;
        float timeForDelegate = time_check - size;
        checking = 0;
        delegate_Action();
        while (time_check > 0.0f)
        {
            time_check -= Time.deltaTime;
            if(time_check <= timeForDelegate)
            {
                timeForDelegate -= size;
                delegate_Between();
                checking++;
            }
            delegate_Size(time_del);
            yield return null;
        }
        
    }

    public void OpenMenu(Delegate_Action delegate_Action = null)
    {
        SetCoroutine();
        if (delegate_Action == null)
            coroutine = StartCoroutine(Cor_Action(UI_Open, ActiveTrue, OpenChild));
        else
            coroutine = StartCoroutine(Cor_Action(UI_Open, delegate_Action, OpenChild));
    }

    public void CloseMenu(Delegate_Action delegate_Action = null)
    {
        SetCoroutine();
        if (delegate_Action == null)
            coroutine = StartCoroutine(Cor_Action(UI_Close, ActiveFalse, CloseChild));
        else
            coroutine = StartCoroutine(Cor_Action(UI_Close, delegate_Action, CloseChild));
    }

    public void Open()
    {
        OpenMenu(ResetChild);
    }
    public void Close()
    {
        CloseMenu();
    }
}
