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
    private Vector3 StartPosition;

    private float startTime;
    //private float distanceLength;

    BombManager bomba;

    Coroutine cor;

    void Start()
    {
        bomba = GetComponent<BombManager>();
        //anim = GetComponent<Animator>();

        //distanceLength = Vector3.Distance(StartPosition, EndPosition);

    }
    
    public void next(Vector3 vec)
    {
        if (cor != null)
            StopCoroutine(cor);
        cor = StartCoroutine(GoBackStage(vec));
    }

    IEnumerator GoBackStage(Vector3 vec)
    {
        //Debug.Log("GoBackStage 코루틴 진입");
        StartPosition = vec;

        Vector3 currPosition;

        startTime = Time.time;
        Map_Group_Script.instance.check = true;
        while (transform.position != StartPosition)
        {
            currPosition = transform.position;
            float step = speed * (Time.time-startTime);
            transform.position = Vector3.MoveTowards(currPosition, StartPosition, step);
            startTime = Time.time;
            
            yield return null;
        }
        yield break;
    }

    public void ReCreate(Vector3 vec)
    {
        if (cor != null)
            StopCoroutine(cor);
        Clear();
        GetComponent<BombManager>().MakeStage();
        transform.position = vec;
    }

    void Clear()
    {
        
        for (int i = 0; i < 10; i++)
        {
            int j = 10;
            if (transform.GetChild(j).tag == "Bomb")
            {
                bomba.PushToPool(bomba.BombList, transform.GetChild(j).gameObject, bomba.InvisibleBomb.transform);
            }

            else if (transform.GetChild(j).tag == "Trap")
            {
                bomba.PushToPool(bomba.TrapList, transform.GetChild(j).gameObject, bomba.InvisibleTrap.transform);
            }

            else if (transform.GetChild(j).tag == "Fever")
            {
                bomba.PushToPool(bomba.FeverList, transform.GetChild(j).gameObject, bomba.InvisibleFever.transform);
            }
        }
    }

}
