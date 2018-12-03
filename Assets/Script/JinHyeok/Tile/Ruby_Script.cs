using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruby_Script : Tile_Script {

    public Vector3 TopRuby = new Vector3(-3.5f, 6.5f, 0);
    BombManager bomb;
    
    
    private void Start()
    {
        bomb = GetComponent<BombManager>();
    }

    protected override void SetBool()
    {
        isTouched = false;
    }

    public override void Touched()
    {
        if (isTouched == false)
        {
            isTouched = true;
            ImageChange(tileSprite[1]);
            InGameManager.instance.AddScore();
            CreateRuby();
            //InGameManager.instance.Jewelry();
            Sound_Script.instance.Play_EffectPopSound();
            RubyManager.instance.AddRuby();
            RubyMove.instance.MoveRuby(TopRuby);
            transform.parent.GetComponent<BombManager>().CheckIsTouched();
        }
    }

    public void CreateRuby()
    {
        GameObject obj = bomb.PopFromPool(bomb.RubyIMGList, 4, this.transform);
        obj.transform.position = this.transform.GetChild(0).transform.position;
        obj.transform.SetParent(this.transform);
    }
}
