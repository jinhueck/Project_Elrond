using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGame_UI_Manager : MonoBehaviour {

    public static InGame_UI_Manager instance;

    public Text Timer;
    public Slider slider;

    public Text Score;
    public Text combo;

    public UI_Fade UI_Fade;
    public UIPause UI_Pause;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        UI_Fade.FadeOut(UI_Fade.Close);
    }
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    public void TimerUI(float time)
    {
        Timer.text = string.Format("{0:N0}", time);
        slider.value = time;        
    }

    public void ScoreUI(int score)
    {
        Score.text =""+score;
    }

    public void ComboUI(int n)
    {
        combo.text = "" + n+" Combo";
    }

}
