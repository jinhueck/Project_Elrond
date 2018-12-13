using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
namespace Assets.SimpleAndroidNotifications
{
    public class NotificationTest_Script : MonoBehaviour
    {

        [SerializeField] private float time_Wait;
        [SerializeField] private string key_Time = "Key_Notification";
        [SerializeField] private int[] timeInfo;
        [SerializeField] Text text_Limit;
        [SerializeField] Button button_Box;
        [SerializeField] int ruby_Increase;

        System.DateTime time_Check;
        System.DateTime time_Now;

        Coroutine cor;

        private void Awake()
        {
            //PlayerPrefs.DeleteKey(key_Time);
            Setup();
        }
        private void OnEnable()
        {
            Setup();
        }

        public void Setup()
        {

            timeInfo = new int[6];
            if (PlayerPrefs.HasKey(key_Time))
            {
               
                string[] item;
                item = PlayerPrefs.GetString(key_Time).Split(',');
                for (int i = 0; i < item.Length; i++)
                {
                    timeInfo[i] = System.Convert.ToInt32(item[i]);
                }
                time_Check = new System.DateTime(timeInfo[0], timeInfo[1], timeInfo[2], timeInfo[3], timeInfo[4], timeInfo[5]);
                Clicked_Box();
            }
            else
            {
                Before_Box();
            }
        }

        public void SendNotif()
        {
            System.DateTime time_Now = System.DateTime.Now;
            time_Check = new System.DateTime(time_Now.Year, time_Now.Month, time_Now.Day, time_Now.Hour, time_Now.Minute, time_Now.Second).AddHours(time_Wait);
            
            string saveTime = time_Check.Year + "," +
                time_Check.Month + "," +
                time_Check.Day + "," +
                time_Check.Hour + "," +
                time_Check.Minute + "," +
                time_Check.Second;
            Debug.Log("saveTime : " + saveTime);
            PlayerPrefs.SetString(key_Time, saveTime);
            NotificationManager.Send(TimeSpan.FromHours(time_Wait),
                "Bubble Pop", 
                "무료 다이아가 충전되었습니다. 다이아 상점에서 수령해 주세요!", 
                Color.white);
        }

        IEnumerator SetText()
        {
            System.TimeSpan check_Gap = time_Check - System.DateTime.Now;
            
            double totalSecond = check_Gap.TotalSeconds;
            Debug.Log("check_Gap : " + check_Gap + "  , totalSecond : " + totalSecond);
            while (totalSecond > 0)
            {
                check_Gap = time_Check - System.DateTime.Now;
                totalSecond = check_Gap.TotalSeconds;
                text_Limit.text = check_Gap.Hours + ":" + check_Gap.Minutes + ":" + check_Gap.Seconds;
                yield return null;
            }
            PlayerPrefs.DeleteKey(key_Time);
            Before_Box();
        }

        void ResetListner()
        {
            button_Box.onClick.RemoveAllListeners();
        }

        public void Before_Box()
        {
            ResetListner();
            text_Limit.text = "받기";
            button_Box.onClick.AddListener(() => GetRuby());
        }
        public void GetRuby()
        {
            if(RubyManager.instance != null)
            {
                IncreaseRuby();
                SendNotif();
                GetDoubleRuby();
            }
        }
        void GetDoubleRuby()
        {
            ResetListner();
            button_Box.onClick.AddListener(() => ShowAds());
            text_Limit.text = "광고 시청시 2배!";
        }

        void ShowAds()
        {
            if(InGameADS_Script.instance != null)
            {
                InGameADS_Script.instance.ShowRewardedAd();
            }
        }

        public void IncreaseRuby()
        {
            RubyManager.instance.Ruby += ruby_Increase;
            RubyManager.instance.PrintRuby();
        }

        public void Clicked_Box()
        {
            ResetListner();
            if (cor != null)
                StopCoroutine(cor);
            cor = StartCoroutine(SetText());
        }
    }
}


