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
        //Debug.Log(tutorialview.transform.position);
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
        move = new Vector3(975, 440, 0);
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
                move = new Vector3(975, 440, 0);
                tutorialview.transform.position = Vector3.Lerp(tutorialview.transform.position, move, Time.deltaTime * 10f);
                break;
            case 1:
                move = new Vector3(675, 440, 0);
                tutorialview.transform.position = Vector3.Lerp(tutorialview.transform.position, move, Time.deltaTime * speed);
                break;

            case 2:
                move = new Vector3(375, 440, 0);
                tutorialview.transform.position = Vector3.Lerp(tutorialview.transform.position, move, Time.deltaTime * speed);
                break;
            case 3:
                move = new Vector3(75, 440, 0);
                tutorialview.transform.position = Vector3.Lerp(tutorialview.transform.position, move, Time.deltaTime * speed);
                break;
            case 4:
                move = new Vector3(-225, 440, 0);
                tutorialview.transform.position = Vector3.Lerp(tutorialview.transform.position, move, Time.deltaTime * speed);
                break;

            case 5:
                move = new Vector3(-525, 440, 0);
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

  /*  IEnumerable MovePage()
    {

        switch(pagenum)
        {
            case 0:
                move = new Vector3(-450, 0, 0);
                this.transform.position = Vector3.Lerp(this.transform.position, move, Time.deltaTime);
                break;

            case 1:
                move = new Vector3(-150, 0, 0);
                this.transform.position = Vector3.Lerp(this.transform.position, move, Time.deltaTime);
                break;
            case 2:
                move = new Vector3(150, 0, 0);
                this.transform.position = Vector3.Lerp(this.transform.position, move, Time.deltaTime);
                break;
            case 3:
                move = new Vector3(450, 0, 0);
                this.transform.position = Vector3.Lerp(this.transform.position, move, Time.deltaTime);
                break;
        }

        yield return new WaitForSeconds(0.1f);
    }*/
}
