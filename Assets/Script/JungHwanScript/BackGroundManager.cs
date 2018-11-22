using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    //private Animator anim;
    //public bool position;
    public float speed;
    private Vector3 StartPosition;
    private Vector3 EndPosition;
    private float startTime;
    private float distanceLength;

    void Start()
    {
        //anim = GetComponent<Animator>();
        
        distanceLength = Vector3.Distance(StartPosition, EndPosition);
        
    }

    void Update()
    {
        
    }

    public void next()
    {   
        if(this.transform.position == new Vector3(0f,0f,0f))
        {
            StartCoroutine("GoBackStage");
        }
        if (this.transform.position == new Vector3(10f, 0f, 0f))
        {
            StartCoroutine("GoStage");
        }

    }

        IEnumerator GoBackStage()
    {
        Debug.Log("코루틴 진입");
        StartPosition = this.transform.position;
        EndPosition = new Vector3(-10f, 0f, 0f);
        Vector3 currPosition;
        startTime = Time.time;
        /*
        if (this.transform.position != endposition)
        {
            this.transform.position = Vector3.MoveTowards(currposition, endposition, step);
            yield return null;
        }
        */
        while (this.transform.position != EndPosition)
        {
            //Debug.Log("와일");
            currPosition = this.transform.position;
            float step = speed * (Time.time-startTime);
            transform.position = Vector3.MoveTowards(currPosition, EndPosition, step);
            startTime = Time.time;
            //Debug.Log("와일 끝");
            yield return null;
        }
        this.transform.position = new Vector3(10f, 0f, 0f);
        //Debug.Log("와일 탈출");
        yield break;
    }

    IEnumerator GoStage()
    {
        Debug.Log("코루틴 진입");
        StartPosition = this.transform.position;
        EndPosition = new Vector3(0f, 0f, 0f);
        Vector3 currPosition;
        startTime = Time.time;
        /*
        if (this.transform.position != endposition)
        {
            this.transform.position = Vector3.MoveTowards(currposition, endposition, step);
            yield return null;
        }
        */
        while (this.transform.position != EndPosition)
        {
            //Debug.Log("와일");
            currPosition = this.transform.position;
            float step = speed * (Time.time - startTime);
            transform.position = Vector3.MoveTowards(currPosition, EndPosition, step);
            startTime = Time.time;
            //Debug.Log("와일 끝");
            yield return null;
        }

        //Debug.Log("와일 탈출");
        yield break;
    }
    /*
    void CheckPosition()
    {
        if(this.gameObject.transform.position == new Vector3(0f,0f,0f))
        {
            //animator.SetTrigger("Stage");
            //animation.Play("Stage");
            anim.SetBool("IsStage", true);
            //anim.GetCurrentAnimatorStateInfo().normalizedTime;
        }

        if (this.gameObject.transform.position == new Vector3(10f, 0f, 0f))
        {
            //animator.SetTrigger("BackStage");
            anim.SetBool("IsBackStage", true);
        }
    }
    
    public void AniFalse()
    {
        anim.SetBool("IsStage", false);
        anim.SetBool("IsBackStage", false);
    }

    public void GoBackGround()
    {
        if (this.gameObject.transform.position == new Vector3(-10f, 0f, 0f))
        {
            this.gameObject.transform.position = new Vector3(10f, 0f, 0f);
            //anim.SetBool("IsBackStage", false);
        }
    }

    public void next()
    {
        CheckPosition();
        
        

        
        if (this.gameObject.transform.position == new Vector3(0f, 0f, 0f))
        {
            anim.SetBool("IsBackStage", false);
        }
        

        //anim.SetBool("IsStage", false);
        //anim.SetBool("IsBackStage", false);
    }*/
}
