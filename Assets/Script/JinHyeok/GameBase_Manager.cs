using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene("StartUI");
    }
    public void PlayScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("JungHwan");
    }
}
