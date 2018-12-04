using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble_Script : Tile_Script
{
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
            transform.parent.GetComponent<BombManager>().CheckIsTouched();
        }
    }
}
