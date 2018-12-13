using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RubyManager : MonoBehaviour {

    public static RubyManager instance;
    public Text RubyText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        RubyText.text = Ruby.ToString();
    }

    public int Ruby
    {
        get
        {
            if (!PlayerPrefs.HasKey("TotalRuby"))
            {
                return 0;
            }
            string tmpTotalRuby = PlayerPrefs.GetString("TotalRuby");
            return int.Parse(tmpTotalRuby);
        }
        set
        {
            PlayerPrefs.SetString("TotalRuby", value.ToString());
        }
    }

    public void PrintRuby()
    {
        RubyText.text = Ruby.ToString();
    }

    public void AddRuby()
    {
        int a = Ruby;
        a++;
        Ruby = a;
        RubyText.text = a.ToString();
    }

    public void ResetRuby()
    {
        Ruby = 0;
    }
}
