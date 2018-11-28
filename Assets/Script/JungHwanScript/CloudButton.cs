using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudButton : MonoBehaviour {

	public void LoadScore()
    {
        PlayCloudDataManager.Instance.LoadFromCloud( (string dataToLoad) =>
        { GoogleLogin.Instance.TopScore = long.Parse(dataToLoad); });
    }

    public void SaveScore()
    {
        PlayCloudDataManager.Instance.SaveToCloud(GoogleLogin.Instance.TopScore.ToString());
    }
}
