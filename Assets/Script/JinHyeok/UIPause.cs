using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPause : MonoBehaviour {

    public void OpenMainScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("JungHwan");
    }

	public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
        
    }
}
