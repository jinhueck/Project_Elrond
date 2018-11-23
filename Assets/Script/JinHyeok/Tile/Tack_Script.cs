using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tack_Script : Tile_Script
{
    protected override void SetBool()
    {
        isTouched = true;
    }

    public override void Touched()
    {
        Sound_Script.instance.Play_EffectHitSound();
        BackGround_Script.instance.Attacked();
        InGameManager.instance.ResetCombo();
    }
}
