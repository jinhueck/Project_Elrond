using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    public GameObject Ground1;
    public GameObject Ground2;
    //private Animator anim;
    //public bool position;
    public float speed;
    private Vector3 StartPosition1;
    private Vector3 StartPosition2;
    private Vector3 EndPosition1;
    private Vector3 EndPosition2;
    private float startTime;
    //private float distanceLength;

    BombManager bomba;
    void Start()
    {
        //anim = GetComponent<Animator>();
        
        //distanceLength = Vector3.Distance(StartPosition, EndPosition);
        bomba = Ground1.transform.GetComponent<BombManager>();
    }
    
    public void next()
    {   
        StartCoroutine("GoBackStage");
        StartCoroutine("GoStage");
        Swap();
        /*
        if (this.transform.position == new Vector3(0f,0f,0f))
        {
            StartCoroutine("GoBackStage");
        }
        if (this.transform.position == new Vector3(10f, 0f, 0f))
        {
            StartCoroutine("GoStage");
        }
        */

    }

        IEnumerator GoBackStage()
    {
        //Debug.Log("GoBackStage 코루틴 진입");
        StartPosition1 = Ground1.transform.position;
        Transform G1 = Ground1.transform;
        EndPosition1 = new Vector3(-10f, 0f, 0f);
        Vector3 currPosition;
        startTime = Time.time;
        /*
        if (this.transform.position != endposition)
        {
            this.transform.position = Vector3.MoveTowards(currposition, endposition, step);
            yield return null;
        }
        */
        while (G1.position != EndPosition1)
        {
            Debug.Log("GoBackStage 와일");
            currPosition = G1.position;
            float step = speed * (Time.time-startTime);
            G1.position = Vector3.MoveTowards(currPosition, EndPosition1, step);
            startTime = Time.time;
            
            yield return null;
        }
        Debug.Log("GoBackStage와일 탈출");
        G1.position = new Vector3(10f, 0f, 0f);

        Clear();

        G1.GetComponent<BombManager>().MakeStage();
        
        
        Debug.Log("GoBackStage 와일 끝");
        yield break;
    }

    void Clear()
    {
        
        for (int i = 0; i < 10; i++)
        {
            int j = 10;
            if (Ground1.transform.GetChild(j).tag == "Bomb")
            {
                bomba.PushToPool(bomba.BombList, Ground1.transform.GetChild(j).gameObject, bomba.InvisibleBomb.transform);
            }

            else if (Ground1.transform.GetChild(j).tag == "Trap")
            {
                bomba.PushToPool(bomba.TrapList, Ground1.transform.GetChild(j).gameObject, bomba.InvisibleTrap.transform);
            }

            else if (Ground1.transform.GetChild(j).tag == "Fever")
            {
                bomba.PushToPool(bomba.FeverList, Ground1.transform.GetChild(j).gameObject, bomba.InvisibleFever.transform);
            }
        }
    }

    IEnumerator GoStage()
    {
        //Debug.Log("GoStage 코루틴 진입");
        StartPosition2 = Ground2.transform.position;
        Transform G2 = Ground2.transform;
        EndPosition2 = new Vector3(0f, 0f, 0f);
        Vector3 currPosition;
        startTime = Time.time;
        
        /*
        if (this.transform.position != endposition)
        {
            this.transform.position = Vector3.MoveTowards(currposition, endposition, step);
            yield return null;
        }
        */


        while (G2.position != EndPosition2)
        {
            Debug.Log("GoStage 와일");
            currPosition = G2.position;
            float step = speed * (Time.time - startTime);
            G2.position = Vector3.MoveTowards(currPosition, EndPosition2, step);
            startTime = Time.time;
            
            yield return null;
        }

        Debug.Log("GoStage 와일 탈출");
        
        yield break;
    }

    void Swap()
    {
        GameObject Temp;

        Temp = Ground1;
        Ground1 = Ground2;
        Ground2 = Temp;
        Debug.Log("스왑끝");
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
