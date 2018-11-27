using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Message : MonoBehaviour {


    public UI_Move move;
    public Text textDest;

    public Vector3 pos_1;
    public Vector3 pos_2;

	public void Open(string _text)
    {
        textDest.text = _text;
        move.pos1 = pos_1;
        move.pos2 = pos_2;
        move.FadeIn(OnEventStart);
    }

    public void OnEventStart()
    {

    }
}
