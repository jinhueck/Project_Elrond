using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delegate_Child : Delegate_Script {

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

    void OpenChild()
    {

    }

    protected IEnumerator Cor_Action(Delegate_Size delegate_Size, Delegate_Action delegate_Action , Delegate_Action delegate_Between = null)
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
}
