using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour {

    public static Test instance;
    private void Awake()
    {
        instance = this;
        btnPause.onClick.AddListener(OnClick_Pause);
        //uiPause.Close();

        fade.FadeOut(fade.Close);
        
    }

    public UIPause uiPause;
    public Button btnPause;
    public UI_Message message;

    public UI_Fade fade;

    public void OnClick_Pause()
    {
        //uiPause.Open();
        message.Open("Test");
    }
}
