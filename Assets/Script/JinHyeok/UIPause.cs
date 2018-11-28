using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPause : MonoBehaviour {

    public uTools.TweenScale tweenScale;

    UnityEngine.Events.UnityAction m_finished;

    private void Awake()
    {
        tweenScale.onFinished.AddListener(OnTweenFinished);
    }

    void OnTweenFinished()
    {
        Debug.Log("QWEQWEQWEQWE");
        if (null != m_finished)
            m_finished();
    }

    public void OnClick_Main()
    {
        InGame_UI_Manager.instance.UI_Fade.FadeIn(OpenMainScene);
    }

    public void OpenMainScene()
    {
        GameBase_Manager.instance.OpenMainScene();
    }

    public void OpenMenu()
    {
        gameObject.SetActive(true);
        tweenScale.from = Vector3.zero;
        tweenScale.to = Vector3.one;
        tweenScale.ResetToBeginning();
        tweenScale.PlayForward();
        Time.timeScale = 0;
    }


    public void CloseMenu()
    {
        tweenScale.from = Vector3.one;
        tweenScale.to = Vector3.zero;
        tweenScale.ResetToBeginning();
        tweenScale.PlayForward();
        gameObject.SetActive(false);

        Time.timeScale = 1;
    }
}
