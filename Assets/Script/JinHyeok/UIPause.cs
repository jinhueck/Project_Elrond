using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPause : MonoBehaviour {

    public uTools.TweenScale tweenScale;

    public void OnClick_Main()
    {
        Test.instance.fade.FadeIn(OpenMainScene);
    }

    public void OpenMainScene()
    {
        GameBase_Manager.instance.OpenMainScene();
    }

	public void Open()
    {
        gameObject.SetActive(true);
        tweenScale.ResetToBeginning();
        tweenScale.PlayForward();
    }

    public void Close()
    {
        gameObject.SetActive(false);
        
    }
}
