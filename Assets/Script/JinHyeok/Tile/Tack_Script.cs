using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tack_Script : Tile_Script
{
    public override void Touched()
    {
        Debug.Log("Bomb Tack!");
        BackGround_Script.instance.Attacked();
    }
}
