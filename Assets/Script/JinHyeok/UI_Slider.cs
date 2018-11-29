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
    [SerializeField] Image Img_Select;

    [SerializeField] private Sprite[] sprite_Tile;
    public void Setup()
    {
        sprite_Tile = Resources.LoadAll<Sprite>("JinHyeok/Img_Tile");
        button = new RectTransform[sprite_Tile.Length];
        MakeList(sprite_Tile.Length);

        int btnLength = button.Length;
        distance = new float[btnLength];

        btnDistance = (int)Mathf.Abs(button[1].GetComponent<RectTransform>().anchoredPosition.x - button[0].GetComponent<RectTransform>().anchoredPosition.x);

        Img_Select.sprite = sprite_Tile[0];
    }

    public void MakeList(int count)
    {
        var  obj_list = Resources.Load("JinHyeok/Prefabs/Panel") as GameObject;
        for(int i = 0; i < count; i ++)
        {
            var newObject = Instantiate(obj_list);
            newObject.transform.GetChild(0).GetComponent<Image>().sprite = sprite_Tile[i];
            newObject.transform.parent = panal.transform;
            RectTransform rect = newObject.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(130 * i, 0);
            rect.localScale = Vector3.one;
            rect.sizeDelta = Vector2.zero;
            button[i] = rect;
        }
    }

    private void Awake()
    {
        Setup();
    }

    void CheckMinButton()
    {
        for (int i = 0; i < button.Length; i++)
        {
            distance[i] = Mathf.Abs(center.transform.position.x - button[i].transform.position.x);
        }

        float minDistance = Mathf.Min(distance);

        for (int i = 0; i < button.Length; i++)
        {
            if (minDistance == distance[i])
            {
                minButtonNum = i;
            }
        }
    }

    private void Update()
    {
        CheckMinButton();
        if (!dragging)
        {
            LerpToButton(minButtonNum * -btnDistance);
        }
    }

    void Sizeup()
    {
        Debug.Log("이거 된다 이야호");
    }


    void LerpToButton(int pos)
    {
        float newX = Mathf.Lerp(panal.anchoredPosition.x, pos, Time.deltaTime * 3f);
        Vector2 newPosition = new Vector2(newX, panal.anchoredPosition.y);

        panal.anchoredPosition = newPosition;
    }

    public void StartDrag()
    {
        dragging = true;
    }

    public void EndDrag()
    {
        CheckMinButton();
        Img_Select.sprite = sprite_Tile[minButtonNum];
        Invoke("Sizeup", 0);
        dragging = false;
        
    }
}
