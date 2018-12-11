using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InGameADS_Script : UnityAdsHelper
{
    public static InGameADS_Script instance;
    [SerializeField] Assets.SimpleAndroidNotifications.NotificationTest_Script notification;
    private void Awake()
    {
        if (InGameADS_Script.instance == null)
            InGameADS_Script.instance = this;
    }

    protected override void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                {
                    Debug.Log("The ad was successfully shown.");

                    notification.IncreaseRuby();
                    notification.Clicked_Box();
                    break;
                }
            case ShowResult.Skipped:
                {
                    Debug.Log("The ad was skipped before reaching the end.");

                    // to do ...
                    // 광고가 스킵되었을 때 처리

                    break;
                }
            case ShowResult.Failed:
                {
                    Debug.LogError("The ad failed to be shown.");

                    // to do ...
                    // 광고 시청에 실패했을 때 처리

                    break;
                }
        }
    }
}
