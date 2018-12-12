using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble_Script : Tile_Script
{

    public override void Setup()
    {
        SetBool();
        SetImg();
        if (InGameManager.instance.CheckFever())
            ImageChange(Map_Group_Script.instance.ReturnFever());
        else
            ImageChange(tileSprite[0]);
    }

    public void SetImg()
    {
        tileSprite[0] = Map_Group_Script.instance.ReturnTile();
        tileSprite[1] = Map_Group_Script.instance.ReturnTileSelect();
    }

    protected override void SetBool()
    {
        isTouched = false;
    }

    public override void Touched()
    {
        if(isTouched == false)
        {
            isTouched = true;
            ImageChange(tileSprite[1]);
            InGameManager.instance.AddScore();
            Sound_Script.instance.Play_EffectPopSound();
            Effect_Script.instance.PopEffect(this.transform);
            transform.parent.GetComponent<BombManager>().CheckIsTouched();
            gameObject.SetActive(false);
        }
    }
}
