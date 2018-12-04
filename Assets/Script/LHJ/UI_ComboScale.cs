using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ComboScale : UI_Open
{

    public Text combo;
    float viewtime;
 

	void Start ()
    {
        //viewtime = 1;
	}
	
	// Update is called once per frame
	void Update ()
    {
        ComboUI();
    }

    public void ComboUI()
    {    
            combo.text = "" + (InGameManager.instance.combo-1) + " Combo";
    }
}
