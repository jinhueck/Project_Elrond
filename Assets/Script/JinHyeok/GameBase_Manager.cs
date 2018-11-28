using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBase_Manager : MonoBehaviour {

    public static GameBase_Manager instance;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OpenMainScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartUI");
    }
    public void PlayScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("JungHwan");
    }
}
