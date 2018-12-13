using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : UI_Open
{
    public int pagenum;
    Vector3 move;
    float speed;
    int maxnum;
    public Image tutorialview;
    public Text pageview;

    private void Awake()
    {
        pagenum = 0;
        speed = 5f;
        maxnum = 4;
    }

    void Update()
    {
        pagemove();
        Pageview();
    }

    public void OpenTutorial()
    {
       
        this.Open_Menu();
    }

    public void CloseTutorial()
    {
        this.Close_Menu();
        pagenum = 0;
        move = new Vector3(1356, 705, 0);
        tutorialview.transform.position = move;
    }

    public void Previous()
    {
        if(pagenum>0)
        pagenum--;

    }

    public void Next()
    {
        if(pagenum<maxnum)
        pagenum++;
        
    }


    public void pagemove()
    {   
        switch (pagenum)
        {

            case 0:
                move = new Vector3(1356, 705, 0);
                tutorialview.transform.position = Vector3.Lerp(tutorialview.transform.position, move, Time.deltaTime * 10f);
                break;
            case 1:
                move = new Vector3(857, 705, 0);
                tutorialview.transform.position = Vector3.Lerp(tutorialview.transform.position, move, Time.deltaTime * speed);
                break;

            case 2:
                move = new Vector3(358, 705, 0);
                tutorialview.transform.position = Vector3.Lerp(tutorialview.transform.position, move, Time.deltaTime * speed);
                break;
            case 3:
                move = new Vector3(-144, 705, 0);
                tutorialview.transform.position = Vector3.Lerp(tutorialview.transform.position, move, Time.deltaTime * speed);
                break;
            case 4:
                move = new Vector3(-640, 705, 0);
                tutorialview.transform.position = Vector3.Lerp(tutorialview.transform.position, move, Time.deltaTime * speed);
                break;

            case 5:
                move = new Vector3(-525, 705, 0);
                tutorialview.transform.position = Vector3.Lerp(tutorialview.transform.position, move, Time.deltaTime * speed);
                break;
        }
    }

    public void Pageview()
    {
        if (pagenum < maxnum)
        {
            pageview.text = (pagenum + 1) + " / " + (maxnum+1);
        }
        else
        {
            pageview.text = "마지막 페이지 입니다";
        }
    }
}
