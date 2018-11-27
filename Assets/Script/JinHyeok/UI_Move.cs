using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Move : MonoBehaviour {

    public uTools.TweenPosition posTween;
    public Vector3 pos1;
    public Vector3 pos2;

    UnityEngine.Events.UnityAction m_finished;

    private void Awake()
    {
        posTween.onFinished.AddListener(OnTweenFinished);
    }

    void OnTweenFinished()
    {
        if (null != m_finished)
            m_finished();
    }

    public void FadeIn(UnityEngine.Events.UnityAction _event)
    {
        m_finished = _event;
        posTween.from = pos1;
        posTween.to = pos2;
        posTween.ResetToBeginning();
        posTween.PlayForward();
    }

    public void FadeOut(UnityEngine.Events.UnityAction _event)
    {
        m_finished = _event;
        posTween.from = pos2;
        posTween.to = pos1;
        posTween.ResetToBeginning();
        posTween.PlayForward();
    }
}
