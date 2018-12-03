using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdsHelper : MonoBehaviour
{
    private const string android_game_id = "2946050";
    private const string ios_game_id = "2946052";

    private const string rewarded_video_id = "rewardedVideo";

    public UI_StartGame startgame;
    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
#if UNITY_ANDROID
        Advertisement.Initialize(android_game_id);
#elif UNITY_IOS
        Advertisement.Initialize(ios_game_id);
#endif
    }

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady(rewarded_video_id))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };

            Advertisement.Show(rewarded_video_id, options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                {
                    Debug.Log("The ad was successfully shown.");

                    InGameManager.instance.playtime += 10f;
                    InGameManager.instance.advview++;
                    startgame.timerreset();
                    startgame.tweenScale.duration = 0.915f;
                    startgame.Open_Menu();
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