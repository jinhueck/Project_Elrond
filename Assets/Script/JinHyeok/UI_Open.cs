﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Open : UI_Base {

    public uTools.TweenScale tweenScale;

    public void Open_Menu()
    {
        Open();
        tweenScale.from = Vector3.zero;
        tweenScale.to = Vector3.one;
        tweenScale.ResetToBeginning();
        tweenScale.PlayForward();
    }


    public void Close_Menu()
    {
        tweenScale.from = Vector3.one;
        tweenScale.to = Vector3.zero;
        tweenScale.ResetToBeginning();
        tweenScale.PlayForward();
        Close();
    }
}