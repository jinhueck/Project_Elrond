using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruby_Script : Tile_Script {

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
            //InGameManager.instance.Jewelry();
            Sound_Script.instance.Play_EffectPopSound();
            RubyManager.instance.AddRuby();
            transform.parent.GetComponent<BombManager>().CheckIsTouched();
        }
    }
}
