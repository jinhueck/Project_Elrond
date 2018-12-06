using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch_Script : MonoBehaviour {

    public Camera camera;
    int layermask;

    public void Awake()
    {
        Setup();
    }

    public void Setup()
    {
        layermask = 1 << LayerMask.NameToLayer("Touch");
    }

	void Update () {
        Vector3 touchPos;


#if (UNITY_ANDROID)
        int count = Input.touchCount;

        if (count == 0)
        {
            Map_Group_Script.instance.check = false;
            return;
        }

        if (Map_Group_Script.instance.check == false)
            for (int i = 0; i < count; i++)
            {
                Touch touch = Input.GetTouch(i);
                touchPos = touch.position;
                touchPos.z = 5f;
                //Debug.Log(touchPos);

                RaycastHit2D hit = Physics2D.Raycast(camera.ScreenToWorldPoint(touchPos), Vector2.zero, Mathf.Infinity, layermask);

                if (hit.collider != null)
                {
                    hit.transform.GetComponent<Tile_Script>().Touched();
                }
                RaycastHit2D hitTest = Physics2D.Raycast(camera.ScreenToWorldPoint(touchPos), Vector2.zero, Mathf.Infinity, 1 << LayerMask.NameToLayer("UI"));
                if (hitTest.collider != null)
                {
                    Debug.Log("UI 찍힘");
                }
            }
#endif
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            touchPos = Input.mousePosition;
        }
#endif
        
    }
}
