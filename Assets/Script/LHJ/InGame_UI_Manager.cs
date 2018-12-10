using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGame_UI_Manager : MonoBehaviour {

    public static InGame_UI_Manager instance;

    public Text Timer;
    public Slider slider;

    public Text Score;

    public UI_Fade UI_Fade;
    public UIPause UI_Pause;
    public FeverAni Fever;

    float timer;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        UI_Fade.FadeOut(UI_Fade.Close);

        timer = 0f;
    }

    public void TimerUI(float time)
    {   
        if (time > 10.5)
        {
            Timer.text = string.Format("{0:N0}", time);
        }
        else
            Timer.text = "<color=#ff0000>" + string.Format("{0:N0}", time) + "</color>";
        slider.value = time;        
    }

    public void ScoreUI(int score)
    {
        Score.text =""+score;
    }
}
