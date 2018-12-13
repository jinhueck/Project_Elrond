using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ui : MonoBehaviour {

    public Text TopScore;
    
    public void GameStart()
    {
        SceneManager.LoadScene("JungHwan");
    }

}
