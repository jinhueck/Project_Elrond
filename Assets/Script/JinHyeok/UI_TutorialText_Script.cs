using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_TutorialText_Script : MonoBehaviour {
    public static UI_TutorialText_Script instance;
    [SerializeField] Delegate_Script delegate_Script;
    [SerializeField] private GameObject ui_Langauge;

    [SerializeField] string key_Langauge = "Set_Language";
    [SerializeField] int num_Language;

    [SerializeField] Text[] text_Tutorial;

    private void Awake()
    {
        if (UI_TutorialText_Script.instance == null)
            UI_TutorialText_Script.instance = this;
        Setup();
    }

    public void Setup()
    {
        delegate_Script = GetComponent<Delegate_Script>();
        delegate_Script.SetTarget(ui_Langauge);

        if (PlayerPrefs.HasKey(key_Langauge))
        {
            num_Language = PlayerPrefs.GetInt(key_Langauge);
        }
        else
        {
            string country = Application.systemLanguage.ToString();
            switch(country)
            {
                case "Korean":
                    num_Language = 0;
                    break;
                case "English":
                    num_Language = 1;
                    break;
            }
            PlayerPrefs.SetInt(key_Langauge, num_Language);
        }
        SetText(num_Language);
    }

    public void SetText(int num)
    {
        num_Language = num;
        PlayerPrefs.SetInt(key_Langauge, num_Language);
        TextAsset text = Resources.Load<TextAsset>("JinHyeok/Language_Info/" + num_Language);
        Debug.Log("text.text : " + text.text);
        string[]  value = text.text.Split('\n');
        for (int i = 0; i < value.Length; i ++)
        {
            text_Tutorial[i].text = value[i];
        }
        CloseLangauge();
    }

    public int ReturnLangauge()
    {
        return num_Language;
    }

    public void OpenLangauge()
    {
        delegate_Script.Scale_Open(() => CloseParent(true));
    }
    public void CloseLangauge()
    {
        delegate_Script.Scale_Close(()=>CloseParent(false)); 
    }
    void CloseParent(bool check)
    {
        ui_Langauge.transform.parent.gameObject.SetActive(check);
    }
}
