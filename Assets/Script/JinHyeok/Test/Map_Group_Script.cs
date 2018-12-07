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

    public GameObject InvisibleBomb;
    public GameObject InvisibleTrap;
    public GameObject InvisibleFever;
    public GameObject InvisibleRuby;

    [SerializeField] private string key_IntSelect = "SetTile";
    [SerializeField] Sprite[] sprites_Tile;
    [SerializeField] Sprite[] sprites_TileSelect;
    [SerializeField] Sprite sprites_Tack;
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
