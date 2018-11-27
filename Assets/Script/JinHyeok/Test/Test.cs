using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour {

    public uTools.TweenScale tweenScale;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void Awake()
    {
        btnPause.onClick.AddListener(OnClick_Pause);
        uiPause.Close();
    }

    public UIPause uiPause;
    public Button btnPause;

    public void OnClick_Pause()
    {
        uiPause.Open();
    }
}
