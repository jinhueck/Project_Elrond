using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    private Animator anim;
    //public bool position;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

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

    public void next()
    {
        CheckPosition();
        
        if (this.gameObject.transform.position == new Vector3(-10f, 0f, 0f))
        {
            anim.SetBool("IsStage", false);
            gameObject.SetActive(false);
            gameObject.transform.position = new Vector3(10f, 0f, 0f);
            gameObject.SetActive(true);
            //anim.SetBool("IsBackStage", false);
        }

        /*
        if (this.gameObject.transform.position == new Vector3(0f, 0f, 0f))
        {
            anim.SetBool("IsBackStage", false);
        }
        */

        //anim.SetBool("IsStage", false);
        //anim.SetBool("IsBackStage", false);
    }
}
