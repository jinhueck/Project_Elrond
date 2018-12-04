using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyMaker : MonoBehaviour {

    [SerializeField] public List<GameObject> RubyIMGList = new List<GameObject>();

    public GameObject InvisibleRubyIMG;

    public GameObject RubyIMG;

    public int poolCount = 5;

    public static RubyMaker instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        InvisibleRubyIMG = new GameObject();
        InvisibleRubyIMG.name = "InvisibleRubyIMG";
        Initialize(RubyIMGList, InvisibleRubyIMG.transform);
    }

    public void Initialize(List<GameObject> list, Transform parent)
    {
        for (int ix = 0; ix < poolCount; ++ix)
        {
            list.Add(CreateItem(4, parent));
        }
    }

    public void PushToPool(List<GameObject> list, GameObject item, Transform parent) //집어넣기
    {
        item.transform.SetParent(parent);
        item.SetActive(false);
        list.Add(item);
    }

    public GameObject PopFromPool(List<GameObject> list, int num, Transform parent) //빼기
    {
        
        if (list.Count == 0 && num == 4)
        {
            list.Add(CreateItem(num, parent));
        }

        GameObject item = list[0];
        list.RemoveAt(0);
        item.transform.SetParent(parent);
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
}
