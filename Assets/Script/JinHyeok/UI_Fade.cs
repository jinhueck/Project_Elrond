using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Fade : UI_Base
{
    public delegate void OnEventFinished();
    public uTools.TweenAlpha alphaTween;

    OnEventFinished m_finished;

    void OnTweenFinished()
    {
        if (null != m_finished)
            m_finished();
    }

    private void Awake()
    {
        alphaTween.onFinished.AddListener(OnTweenFinished);
    }

    public void FadeIn(OnEventFinished _event)
    {
        Open();
        m_finished = _event;
        alphaTween.from = 0f;
        alphaTween.to = 1f;
        alphaTween.ResetToBeginning();
        alphaTween.PlayForward();
    }

    public void FadeOut(OnEventFinished _event)
    {
        Open();
        m_finished = _event;
        alphaTween.from = 1f;
        alphaTween.to = 0f;
    }

}
