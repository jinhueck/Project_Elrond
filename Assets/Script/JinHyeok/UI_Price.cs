using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Price : MonoBehaviour {

    Delegate_Script delegate_Script;
    [SerializeField] private GameObject ui_Price;

    private void Awake()
    {
        Setup();
    }

    public void Setup()
    {
        delegate_Script = GetComponent<Delegate_Script>();
        delegate_Script.SetTarget(ui_Price);
    }

    public void Open_Price()
    {
        delegate_Script.Scale_Open();
        this.GetComponent<Assets.SimpleAndroidNotifications.NotificationTest_Script>().Setup();
    }
    public void Close_Price()
    {
        delegate_Script.Scale_Close();
    }
}
