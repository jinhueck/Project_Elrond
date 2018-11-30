using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoogleFX : MonoBehaviour {

    public static GoogleFX Instance { get; private set; }

    void Start()
    {
        Instance = this;
    }


}
