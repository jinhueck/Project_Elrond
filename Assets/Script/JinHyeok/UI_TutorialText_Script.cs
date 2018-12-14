using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_TutorialText_Script : MonoBehaviour {

    [SerializeField] string key_Langauge = "Set_Language";
    [SerializeField] int num_Language;

    [SerializeField] Text[] text_Tutorial;

    private void Awake()
    {
        Setup();
    }

    public void Setup()
    {
        if(PlayerPrefs.HasKey(key_Langauge))
        {
            num_Language = PlayerPrefs.GetInt(key_Langauge);
        }
        else
        {
            num_Language = 0;
            PlayerPrefs.SetInt(key_Langauge, num_Language);
        }
        SetText(num_Language);
    }
    [SerializeField] string[] value;
    [SerializeField] TextAsset text;
    void SetText(int num)
    {
        num_Language = num;
        PlayerPrefs.SetInt(key_Langauge, num_Language);
        text = Resources.Load<TextAsset>("JinHyeok/Language_Info/" + num_Language);
        Debug.Log("text.text : " + text.text);
        value = text.text.Split('\n');
        for (int i = 0; i < value.Length; i ++)
        {
            text_Tutorial[i].text = value[i];
        }
    }
}
