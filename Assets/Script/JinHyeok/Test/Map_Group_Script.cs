using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Group_Script : MonoBehaviour {

    public static Map_Group_Script instance;

    public GameObject Ground1;
    public GameObject Ground2;
    public GameObject Ground3;

    public Vector3 Pos_right;
    public Vector3 Pos2_middle;
    public Vector3 Pos_left;
    public bool check;

    BombManager[] bombManagers = new BombManager[3];

    public GameObject InvisibleBomb;
    public GameObject InvisibleTrap;
    public GameObject InvisibleFever;
    public GameObject InvisibleRuby;

    [SerializeField] private string key_IntSelect = "SetTile";
    [SerializeField] Sprite[] sprites_Tile;
    [SerializeField] Sprite[] sprites_TileSelect;
    [SerializeField] Sprite sprites_Tack;
    [SerializeField] Sprite sprites_Fever;
    public GameObject obj;
    int intSelected;
    private void Awake()
    {
        if (Map_Group_Script.instance == null)
            Map_Group_Script.instance = this;
        Pos_right = new Vector3(10, 0, 0);
        Pos2_middle = new Vector3(0, 0, 0);
        Pos_left = new Vector3(-10, 0, 0);
        check = false;

        InvisibleBomb = new GameObject();
        InvisibleTrap = new GameObject();
        InvisibleFever = new GameObject();
        InvisibleRuby = new GameObject();

        InvisibleBomb.name = "InvisibleBomb";
        InvisibleTrap.name = "InvisibleTrap";
        InvisibleFever.name = "InvisibleFever";
        InvisibleRuby.name = "InvisibleRuby";

        intSelected = PlayerPrefs.GetInt(key_IntSelect);
        Debug.Log("intSelected checkNum : " + intSelected);

        sprites_Tile = Resources.LoadAll<Sprite>("JinHyeok/Img_Tile");
        sprites_TileSelect = Resources.LoadAll<Sprite>("JinHyeok/Img_TileSelect");
        sprites_Tack = Resources.Load<Sprite>("JinHyeok/Img_Tack/Tile"+ intSelected);
        sprites_Fever = Resources.Load<Sprite>("JinHyeok/Fever");

        bombManagers[0] = Ground1.GetComponent<BombManager>();
        bombManagers[1] = Ground2.GetComponent<BombManager>();
        bombManagers[2] = Ground3.GetComponent<BombManager>();
    }

    public int ReturnSelectNum()
    {
        return intSelected;
    }

    public Sprite ReturnTile()
    {
        return sprites_Tile[intSelected];
    }
    public Sprite ReturnTileSelect()
    {
        return sprites_TileSelect[intSelected];
    }
    public Sprite ReturnTack()
    {
        return sprites_Tack;
    }
    public Sprite ReturnFever()
    {
        return sprites_Fever;
    }
    void ChangeImg_Fever(BombManager bombManager)
    {
        int num = bombManager.BombList.Count;
        for(int i =0; i < num; i ++)
        {
            if (bombManager.BombList[i].tag == "Bomb")
                bombManager.BombList[i].GetComponent<SpriteRenderer>().sprite = sprites_Fever;
        }
    }
    void ChangeImg_FeverEnd(BombManager bombManager)
    {
        int num = bombManager.BombList.Count;
        for (int i = 0; i < num; i++)
        {
            if (bombManager.BombList[i].tag == "Bomb")
                bombManager.BombList[i].GetComponent<SpriteRenderer>().sprite = sprites_Tile[intSelected];
        }
    }

    public void Fever_Start()
    {
        ChangeImg_Fever(bombManagers[0]);
        ChangeImg_Fever(bombManagers[1]);
        ChangeImg_Fever(bombManagers[2]);
        int num = InvisibleBomb.transform.childCount;
        for (int i = 0; i < num; i++)
        {
            InvisibleBomb.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = sprites_Fever;
        }
    }

    public void Fever_End()
    {
        ChangeImg_FeverEnd(bombManagers[0]);
        ChangeImg_FeverEnd(bombManagers[1]);
        ChangeImg_FeverEnd(bombManagers[2]);

        int num = InvisibleBomb.transform.childCount;
        for(int i = 0; i < num; i ++)
        {
            InvisibleBomb.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = sprites_Tile[intSelected];
        }
    }

    public void next()
    {
        InGameManager.instance.AddCombo();

        Ground1.GetComponent<BackGroundManager>().next(Pos2_middle);
        Ground2.GetComponent<BackGroundManager>().next(Pos_left);
        Ground3.GetComponent<BackGroundManager>().ReCreate(Pos_right);

        GameObject t1;
        t1 = Ground3;

        Ground3 = Ground2;
        Ground2 = Ground1;
        Ground1 = t1;
    }


}
