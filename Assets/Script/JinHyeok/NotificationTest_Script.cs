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
            Setup();
        }

        public void Setup()
        {
            timeInfo = new int[6];
            if (PlayerPrefs.HasKey(key_Time))
            {
               
                string[] item;
                item = PlayerPrefs.GetString(key_Time).Split(',');
                for (int i = 0; i < timeInfo.Length; i++)
                {
                    timeInfo[i] = System.Convert.ToInt32(item[i]);
                }
                time_Check = new System.DateTime(timeInfo[0], timeInfo[1], timeInfo[2], timeInfo[3], timeInfo[4], timeInfo[5]);
                Clicked_Box();
            }
            else
            {
                Debug.Log("여기는 들어와진다 노티");
                Before_Box();
            }
        }

        public void SendNotif()
        {
            System.DateTime time_Now = System.DateTime.Now;
            time_Check = new System.DateTime(time_Now.Year, time_Now.Month, time_Now.Day, time_Now.Hour + 6, time_Now.Minute, time_Now.Second).AddHours(time_Wait);
            
            string saveTime = time_Check.Year + "," +
                time_Check.Month + "," +
                time_Check.Day + "," +
                time_Check.Hour + "," +
                time_Check.Minute + "," +
                time_Check.Second;
            Debug.Log("saveTime : " + saveTime);
            PlayerPrefs.SetString(key_Time, saveTime);
            NotificationManager.Send(TimeSpan.FromHours(time_Wait),
                "Go ahead and get DIA!", 
                "The DIA box is being prepared. Go ahead and get DIA.", 
                Color.white);
        }

        IEnumerator SetText()
        {
            Debug.Log("여기까지는 들어와진다 노티피케이션");
            System.TimeSpan check_Gap = System.DateTime.Now - time_Check;
            double totalSecond = check_Gap.TotalSeconds;
            while (totalSecond > 0)
            {
                check_Gap = time_Check - System.DateTime.Now;
                totalSecond = check_Gap.TotalSeconds;
                Debug.Log(check_Gap.Hours + ":" + check_Gap.Minutes + ":" + check_Gap.Seconds);
                text_Limit.text = check_Gap.Hours + ":" + check_Gap.Minutes + ":" + check_Gap.Seconds;
                yield return null;
            }
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
                RubyManager.instance.Ruby += ruby_Increase;
                SendNotif();
                Clicked_Box();
            }
        }

        void Clicked_Box()
        {
            ResetListner();
            if (cor != null)
                StopCoroutine(cor);
            cor = StartCoroutine(SetText());
        }
    }
}


