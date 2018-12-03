using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverAni : MonoBehaviour {

    public AnimationCurve curve;

    public float AnimationSpeed;
    public float MovementScale;
    public Vector3 nowPos;

    private float timer;
    private void Awake()
    {
        nowPos = transform.localScale;
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * AnimationSpeed;
        if (timer > 1)
        {
            timer -= 1;
        }
        float y = curve.Evaluate(timer) * MovementScale;
        transform.localScale = nowPos * y;
    }
}
