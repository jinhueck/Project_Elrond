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
            RubyMaker.instance.CreateRuby(this.transform.position);
            //InGameManager.instance.Jewelry();
            Sound_Script.instance.Play_EffectRubbySound();
            RubyManager.instance.AddRuby();
            //RubyMove.instance.MoveRuby(TopRuby);
            transform.parent.GetComponent<BombManager>().CheckIsTouched();
        }
    }

  
}
