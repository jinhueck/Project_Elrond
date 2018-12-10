using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Slider : MonoBehaviour {

    public GameObject ui_Slider;

    public RectTransform panal;
    public RectTransform[] button;
    public RectTransform center;
    [SerializeField] private float[] distance;
    [SerializeField] private bool dragging = false;
    private int btnDistance;
    [SerializeField] private int minButtonNum;
    [SerializeField] Image Img_Select;
    [SerializeField] Text text_Select;
    [SerializeField] int int_Select;
    [SerializeField] ShopDB_Script db_shop;
    [SerializeField] bool check_SliderOpen;

    [SerializeField] private Sprite[] sprite_Tile;
    [SerializeField] Delegate_Script delegate_Script;
    [SerializeField] private string key_IntSelect = "SetTile";

    public void Setup()
    {
        db_shop.Setup();

        sprite_Tile = Resources.LoadAll<Sprite>("JinHyeok/Img_Tile");
        button = new RectTransform[sprite_Tile.Length];
        MakeList(sprite_Tile.Length);

        int btnLength = button.Length;
        distance = new float[btnLength];

        btnDistance = (int)Mathf.Abs(button[1].GetComponent<RectTransform>().anchoredPosition.x - button[0].GetComponent<RectTransform>().anchoredPosition.x);
        SetupIntSelect();

        delegate_Script = gameObject.GetComponent<Delegate_Script>();
        delegate_Script.SetTarget(ui_Slider);

        check_SliderOpen = false;
        ui_Slider.SetActive(false);
    }

    public void SetupIntSelect()
    {
        if(PlayerPrefs.HasKey(key_IntSelect) == false)
        {
            int_Select = 0;
            PlayerPrefs.SetInt(key_IntSelect, int_Select);
        }
        else
        {
            int_Select = PlayerPrefs.GetInt(key_IntSelect);
        }
        Img_Select.sprite = sprite_Tile[int_Select];
    }

    public void SetIntSelect()
    {
        PlayerPrefs.SetInt(key_IntSelect, int_Select);
    }

    public int GetIntSelect()
    {
        return int_Select;
    }

    public void MakeList(int count)
    {
        var  obj_list = Resources.Load("JinHyeok/Panel") as GameObject;
        for(int i = 0; i < count; i ++)
        {
            var newObject = Instantiate(obj_list);
            newObject.transform.GetChild(0).GetComponent<Image>().sprite = sprite_Tile[i];
            newObject.transform.parent = panal.transform;
            RectTransform rect = newObject.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(Mathf.Abs(rect.sizeDelta.x) * i, 0);
            rect.localScale = Vector3.one;
            rect.sizeDelta = Vector2.zero;
            button[i] = rect;

            if (db_shop.SetMoney(i) == 0)
            {
                ChangeButtonText(i, db_shop.ReturnMoney(i).ToString());
                int a = i;
                rect.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() => Buy(a));
            }
            else
            {
                ChangeButtonText(i, "장 착");
                SetSelectedButton(rect.transform);
            }
            rect.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(()=>StartUIMusicManager.instance.ClickSound());
        }
    }

    void SetSelectedButton(Transform trans)
    {
        trans.GetChild(1).GetComponent<Button>().onClick.RemoveAllListeners();
        trans.GetChild(1).GetComponent<Button>().onClick.AddListener(() => ButtonSelect());

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
        Img_Select.sprite = sprite_Tile[minButtonNum];
        text_Select.text = db_shop.ReturnName(minButtonNum).ToString();
        int_Select = minButtonNum;
    }

    

void SizeUpSelected()
    {
        for (int i = 0; i < button.Length; i++)
        {
            float distance_Button = distance[i] / 130;
            if (distance_Button < 1)
            {
                RectTransform rect = button[i].transform.GetChild(0).GetComponent<RectTransform>();
                rect.localScale = Vector3.one + new Vector3(0.5f, 0.5f, 0.5f) * (1 - distance_Button);
                rect.sizeDelta = Vector2.zero + new Vector2(0.5f, 0.5f) * (1 - distance_Button);
            }
            else
            {
                button[i].localScale = Vector3.one;
                button[i].sizeDelta = Vector2.zero;
            }
        }
    }

    private void Update()
    {
        if(ui_Slider.active)
        {
            CheckMinButton();
            SizeUpSelected();
            if (!dragging)
            {
                LerpToButton(minButtonNum * -btnDistance);
            }
        }
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
        dragging = false;
        
    }

    void ChangeButtonText(int i , string value)
    {
        button[i].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = value;
    }

    public void UIOpen()
    {
        if(!check_SliderOpen)
        {
            check_SliderOpen = true;
            Vector2 pos = new Vector2(int_Select * -btnDistance, panal.anchoredPosition.y);
            panal.anchoredPosition = pos;
            ui_Slider.SetActive(true);
            delegate_Script.Move_Open();
        }
        else
        {
            check_SliderOpen = false;
            delegate_Script.Move_Close();
        }
        
    }

    public void ButtonSelect()
    {
        check_SliderOpen = false;
        SetIntSelect();
        delegate_Script.Move_Close();
    }

    public void Buy(int i)
    {
        int forBuy = db_shop.ReturnMoney(i);
        RubyManager rubyManager = RubyManager.instance;
        int hasMoney = rubyManager.Ruby;
        if (hasMoney >= forBuy)
        {
            rubyManager.Ruby = hasMoney - forBuy;

            db_shop.SetShopInfo(i);
            ChangeButtonText(i, "장 착");
            SetSelectedButton(button[i].transform);
        }
    }
}
