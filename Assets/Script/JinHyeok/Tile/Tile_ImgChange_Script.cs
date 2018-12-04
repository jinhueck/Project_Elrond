using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_ImgChange_Script : MonoBehaviour {

    public static Tile_ImgChange_Script instance;

    [SerializeField] private string key_IntSelect = "SetTile";
    [SerializeField] Sprite[] sprites_Tile;
    private void Awake()
    {
        if (Tile_ImgChange_Script.instance == null)
            Tile_ImgChange_Script.instance = this;
        Setup();
    }

    void Setup()
    {
        int checkNum = PlayerPrefs.GetInt(key_IntSelect);
        sprites_Tile[0] = Resources.Load<Sprite>("JinHyeok/Img_Tile/Tile" + checkNum);
        sprites_Tile[1] = Resources.Load<Sprite>("JinHyeok/Img_TileSelect/Tile" + checkNum);
    }

    public Sprite[] GetSprites()
    {
        return sprites_Tile;
    }
}
