using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyMaker : MonoBehaviour {

    [SerializeField] public List<GameObject> RubyIMGList = new List<GameObject>();
    public Vector3 TopRuby = new Vector3(-3.5f, 6.5f, 0);

    public GameObject Ruby_False;
    public GameObject Ruby_True;
    public GameObject RubyIMG;
    RubyMove move;

    public int poolCount = 3;

    public static RubyMaker instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        Initialize(RubyIMGList, Ruby_False.transform);
        move = GetComponent<RubyMove>();
    }

    public void Initialize(List<GameObject> list, Transform parent)
    {
        for (int ix = 0; ix < poolCount; ++ix)
        {
            list.Add(CreateItem(4, parent));
        }
    }

    public void PushToPool(List<GameObject> list, GameObject item) //집어넣기
    {
        item.transform.SetParent(Ruby_False.transform);
        item.SetActive(false);
        list.Add(item);
    }

    public GameObject PopFromPool(List<GameObject> list, int num) //빼기
    {
        
        if (list.Count == 0 && num == 4)
        {
            list.Add(CreateItem(num, Ruby_False.transform));
        }

        GameObject item = list[0];
        list.RemoveAt(0);
        item.transform.SetParent(Ruby_True.transform);
        item.SetActive(true);

        return item;
    }

    private GameObject CreateItem(int num, Transform parent)
    {
        GameObject item = null;
        if (num == 4)
        {
            item = Object.Instantiate(RubyIMG) as GameObject;
            item.name = "RubyIMG";
            item.transform.SetParent(parent);
            item.SetActive(false);
        }
        return item;
    }

    public void CreateRuby(Vector3 pos)
    {
        Debug.Log("크리에이트루비 진입");
        GameObject obj = PopFromPool(RubyIMGList, 4);
        Debug.Log("루비 팝 완료");
        obj.transform.position = pos;
        Debug.Log("루비 포지션 변경");
        //move.MoveRuby(TopRuby);
        obj.GetComponent<RubyMove>().MoveRuby(TopRuby);
        Debug.Log("무브루비");
        //obj.transform.SetParent(this.transform);
    }
}
