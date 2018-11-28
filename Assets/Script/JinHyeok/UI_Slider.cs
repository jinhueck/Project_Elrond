using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Slider : MonoBehaviour {

    public RectTransform panal;
    public RectTransform[] button;
    public RectTransform center;
    [SerializeField] private float[] distance;
    private bool dragging = false;
    private int btnDistance;
    [SerializeField] private int minButtonNum;

    private void Start()
    {
        int btnLength = button.Length;
        distance = new float[btnLength];

        btnDistance = (int)Mathf.Abs(button[1].GetComponent<RectTransform>().anchoredPosition.x - button[0].GetComponent<RectTransform>().anchoredPosition.x);
        Debug.Log("btnDistance : " + btnDistance);
    }

    private void Update()
    {
        for(int i = 0; i < button.Length; i ++)
        {
            distance[i] = Mathf.Abs(center.transform.position.x - button[i].transform.position.x);
        }

        float minDistance = Mathf.Min(distance);
        
        for(int i = 0; i < button.Length; i ++)
        {
            if(minDistance == distance[i])
            {
                minButtonNum = i;
            }
        }
        if(!dragging)
        {
            LerpToButton(minButtonNum * -btnDistance);
        }
    }

    void LerpToButton(int pos)
    {
        float newX = Mathf.Lerp(panal.anchoredPosition.x, pos, Time.deltaTime * 1.5f);
        Debug.Log("newX : " + newX);
        Vector2 newPosition = new Vector2(newX, panal.anchoredPosition.y);

        panal.anchoredPosition = newPosition;
    }

    public void StartDrag()
    {
        dragging = true;
    }

    public void EndDrag()
    {
        dragging = false;
    }
}
