using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Move_Script : MonoBehaviour {

    public float effect_Speed;
    public RectTransform rect;
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    void Update () {
        rect.Rotate(0, 0, effect_Speed * Time.deltaTime);
    }
}
