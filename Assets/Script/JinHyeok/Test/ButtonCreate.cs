using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCreate : MonoBehaviour {

    public Canvas canvas;
    public GameObject obj;
    int i = 0;
	public void ButonCreate()
    {
        if(i < 2)
        {
            var nButton = Instantiate(obj);
            nButton.transform.parent = canvas.transform;
            Button btn = nButton.GetComponent<Button>();
            if (i == 0)
                btn.onClick.AddListener(() => nButton.GetComponent<Button_Setup>().Print());
            else if (i == 1)
                btn.onClick.AddListener(() => nButton.GetComponent<Button_Setup>().Print2());
            i++;
        }
        
    }
}
