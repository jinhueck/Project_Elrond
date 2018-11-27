using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    public Text Timer;
    public Slider slider;

    public Text Score;
    public Text combo;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }

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
