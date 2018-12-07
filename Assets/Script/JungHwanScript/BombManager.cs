using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour {

    //public static BombManager instance;

    //뽁뽁이 리스트
    public GameObject prefab = null;
    public int poolCount = 0;


    [SerializeField] public List<GameObject> BombList = new List<GameObject>();
    [SerializeField] public List<GameObject> TrapList = new List<GameObject>();
    [SerializeField] public List<GameObject> FeverList = new List<GameObject>();
    [SerializeField] public List<GameObject> RubyList = new List<GameObject>();

    Map_Group_Script map_Group;

    public GameObject Bomb;
    public GameObject Trap;
    public GameObject Fever;
    public GameObject Ruby;
    
    private int randomnum;
    private int[] randArray;

    // Use this for initialization

    //루비생성
    int makeRuby;
    Tile_Script setup;

    int T = 0;

    private void Start()
    {
        map_Group = Map_Group_Script.instance;
        /*
        if(instance == null)
        {
            instance = this;
        }
        */
        MakeStage();             
    }
    
    public void MakeStage()
    {   
        bool what = true;
        GetRandomInt(3, 0, 10);
        
        
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < randArray.Length; j++)
            {
                if (i == randArray[j])
                {
                    GameObject obj2 = PopFromPool(1,map_Group.InvisibleTrap.transform);
                    obj2.transform.position = this.transform.GetChild(i).transform.position;
                    obj2.transform.SetParent(this.transform);
                    TrapList.Add(obj2);
                    
                    //GameObject obj2 = Instantiate(Trap, this.transform.GetChild(i).transform.position, Quaternion.identity);
                    //obj2.transform.parent = ;
                    what = false;
                    break;
                }
                else
                {
                    what = true;
                }
            }
            if (what == true)
            {
                MakeRuby(0,10);
                Debug.Log(makeRuby);
                if (makeRuby == 5)
                {
                    Debug.Log("루비생성" + makeRuby);
                    GameObject obj = PopFromPool(3, map_Group.InvisibleRuby.transform);
                    obj.transform.position = this.transform.GetChild(i).transform.position;
                    obj.transform.SetParent(this.transform);
                    RubyList.Add(obj);

                    //obj.GetComponent<Tile_Script>().Setup();
                }
                else if(makeRuby !=5)
                {
                    GameObject obj = PopFromPool(0, map_Group.InvisibleBomb.transform);   
                    obj.transform.position = this.transform.GetChild(i).transform.position;
                    obj.transform.SetParent(this.transform);
                    obj.GetComponent<Tile_Script>().Setup();
                    BombList.Add(obj);
                }
                //GameObject obj = Instantiate(Bomb, this.transform.GetChild(i).transform.position, Quaternion.identity);
                //obj.transform.parent = ;
            }
        }
    }
    
    public int MakeRuby(int min, int max)
    {
        makeRuby = Random.Range(min, max);

        return makeRuby;
    }

    public int[] GetRandomInt(int length, int min, int max)
    {
        randArray = new int[length];
        bool isSame;

        for (int i = 0; i < length; ++i)
        {
            while (true)
            {
                randArray[i] = Random.Range(min, max);
                isSame = false;

                for (int j = 0; j < i; ++j)
                {
                    if (randArray[j] == randArray[i])
                    {
                        isSame = true;
                        break;
                    }
                }
                if (!isSame) break;
            }
        }
        return randArray;
    }

    public void Initialize(List<GameObject> list, Transform parent = null)
    {
        for (int ix = 0; ix < poolCount; ++ix)
        {
            list.Add(CreateItem(0,parent));
        }
    }
    //집어넣기
    public void PushToPool(GameObject item, Transform parent)
    {
        item.transform.SetParent(parent);
        item.SetActive(false);
    }
    //빼기
    public GameObject PopFromPool(int num, Transform parent)
    {
        GameObject obj;
        if (parent.childCount == 0)
        {
            obj = CreateItem(num, parent);
        }
        else
        {
            obj = parent.GetChild(0).gameObject;
        }
        obj.SetActive(true);
        return obj;
    }
    //생성
    private GameObject CreateItem(int num,Transform parent)
    {
        GameObject item = null;
        if (num == 0)
        {
            item = Object.Instantiate(Bomb) as GameObject;
            item.name = "Bomb";
            item.transform.SetParent(parent);
            item.SetActive(false);
        }
        if (num == 1)
        {
            item = Object.Instantiate(Trap) as GameObject;
            item.name = "Trap";
            item.transform.SetParent(parent);
            item.SetActive(false);
        }
        if (num == 2)
        {
            item = Object.Instantiate(Fever) as GameObject;
            item.name = "Fever";
            item.transform.SetParent(parent);
            item.SetActive(false);
        }
        if (num == 3)
        {
            item = Object.Instantiate(Ruby) as GameObject;
            item.name = "Ruby";
            item.transform.SetParent(parent);
            item.SetActive(false);
        }
        return item;
    }

    public void CheckIsTouched()
    {
        T++;
        if (T == 7)
        {
            Map_Group_Script.instance.next();
            T = 0;
        }
    }
}
