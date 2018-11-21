using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour {

    public GameObject Bomb;
    public GameObject Trap;
    private int randomnum;

	// Use this for initialization
	void Start ()
    {
        randomnum = Random.Range(1, 11);
        for (int i=1; i<=10; i++)
        {
            if (i == randomnum)
            {
                Instantiate(Trap, GameObject.Find("Tile" + i).transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(Bomb, GameObject.Find("Tile" + i).transform.position, Quaternion.identity);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int[] GetRandomInt(int length, int min, int max)
    {
        int[] randArray = new int[length];
        bool isSame;

        for (int i = 0; i < length; ++i)
        {
            while (true)
            {
                randArray[i] = Random.Range(min, max);
                isSame = false;

                for (int j = 0; j < i; ++j)
                {
                    if (randArray[j] == randArray[i])
                    {
                        isSame = true;
                        break;
                    }
                }
                if (!isSame) break;
            }
        }
        return randArray;
    }
}
