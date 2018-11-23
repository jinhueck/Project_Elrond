using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble_Script : Tile_Script
{

    public override void Touched()
    {
        Debug.Log("Bomb bubble!");
        if(isTouched == false)
        {
            isTouched = true;
            ImageChange(tileSprite[1]);
            InGameManager.instance.AddScore();
        }
    }
}
