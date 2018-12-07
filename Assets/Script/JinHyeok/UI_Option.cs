using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Option : MonoBehaviour {
    public Delegate_Child ui_Option;
    public GameObject target;
    bool isOpen;
    private void Awake()
    {
        Setup();
    }

    public void Setup()
    {
        ui_Option = this.GetComponent<Delegate_Child>();
        ui_Option.SetTarget(target);
        isOpen = false;
    }

    public void Open()
    {
        if(!isOpen)
        {
            ui_Option.OpenMenu(ui_Option.ResetChild);
        }
            
        else
            ui_Option.CloseMenu();
        isOpen = !isOpen;
    }
}
