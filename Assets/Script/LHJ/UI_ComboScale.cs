using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ComboScale : UI_Open
{
    public Text combo;
	
	void Update ()
    {
        ComboUI();
    }

    public virtual void Open_Menu()
    {
        Open();
        tweenScale.from = Vector3.zero;
        tweenScale.to = Vector3.one;
        tweenScale.ResetToBeginning();
        tweenScale.PlayForward();
    }

    public void ComboUI()
    {    
            combo.text = "" + (InGameManager.instance.combo-1) + " Combo";
    }
}
