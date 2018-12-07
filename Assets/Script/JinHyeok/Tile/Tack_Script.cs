using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tack_Script : Tile_Script
{
    bool ischecked;

    public override void Setup()
    {
        ischecked = false;
        SetBool();
        SetImg();
        ImageChange(tileSprite[0]);
    }
    protected override void SetBool()
    {
        isTouched = true;
    }
    public void SetImg()
    {
        tileSprite[0] = Map_Group_Script.instance.ReturnTack();
    }

    public override void Touched()
    {
        if(ischecked == false)
        {
            ischecked = true;
            StartCoroutine(Attacked());
        }
    }

    IEnumerator Attacked()
    {
        ischecked = true;
        Sound_Script.instance.Play_EffectHitSound();
        BackGround_Script.instance.Attacked();
        InGameManager.instance.ResetCombo();
        yield return new WaitForSeconds(0.5f);
        ischecked = false;
    }
}
