using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopDB_Script : MonoBehaviour {
    [SerializeField]private Sheet1 shit;

    string key_Shop = "Check_Shop";
    [SerializeField]private int[] buyInfo;
    public void Setup ()
    {
        shit = Resources.Load<Sheet1>("JinHyeok/ShopDB") ;
        Debug.Log("This is Shit Length : " + shit.dataArray.Length);
        buyInfo = FindShopInfo();
    }

    public string ReturnName(int i)
    {
        return shit.dataArray[i].Name[0];
    }
    public int ReturnMoney(int i)
    {
        return System.Convert.ToInt32(shit.dataArray[i].Money[0]);
    }

    public int SetMoney(int i)
    {
        return buyInfo[i];
    }

    int[] FindShopInfo()
    {
        int size = shit.dataArray.Length;
        int[] shopInfo = new int[size];
        if (PlayerPrefs.GetString(key_Shop) != "")
        {
            string[] item;
            item = PlayerPrefs.GetString(key_Shop).Split(',');
            for (int i = 0; i < shopInfo.Length; i++)
            {
                shopInfo[i] = System.Convert.ToInt32(item[i]);
            }
        }
        else
        {
            string value = shopInfo[0].ToString();
            for(int i = 1; i < size; i ++)
            {
                value += "," + shopInfo[i];
            }
            PlayerPrefs.SetString(key_Shop, value);
        }
        return shopInfo;
    }

    public void SetShopInfo(int num)
    {
        buyInfo[num] = 1;

        string value = buyInfo[0].ToString();
        for (int i = 1; i < buyInfo.Length; i++)
        {
            value += "," + buyInfo[i];
        }
        PlayerPrefs.SetString(key_Shop, value); 
    }
}
