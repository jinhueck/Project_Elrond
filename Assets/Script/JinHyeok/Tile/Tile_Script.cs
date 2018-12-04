using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Script : MonoBehaviour {

    [SerializeField] protected TileType type;         //뽁뽁이, 압정, 황금 뽁뽁이를 나누기 위한 enum
    [SerializeField] protected Sprite[] tileSprite;   //0이 안터진 이미지, 1은 터진 이미지
    [SerializeField] protected bool isTouched;        //터졌는지 안터졌는지 확인
    

    private void Awake()
    {
        Setup(); 
    }


    public virtual void Setup()
    {
        SetBool();
        ImageChange(tileSprite[0]);
    }
    protected virtual void SetBool()
    {

    }

    public bool IsTouched()
    {
        return isTouched;
    }

    public virtual void Touched()
    {
    }

    protected void ImageChange(Sprite sprite)
    {
        this.GetComponent<SpriteRenderer>().sprite = sprite;
    }
}

public enum TileType
{
    bubble = 0,
    bomb,
    gold
}
