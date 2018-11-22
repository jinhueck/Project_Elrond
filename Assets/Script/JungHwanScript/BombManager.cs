using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour {

    public GameObject Bomb;
    public GameObject Trap;
    private int randomnum;
    private int[] randArray;

    // Use this for initialization
    void Start ()
    {
        MakeStage();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MakeStage()
    {
        bool what = true;
        GetRandomInt(3, 0, 10);
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < randArray.Length; j++)
            {
                if (i == randArray[j])
                {   
                    GameObject obj2 = Instantiate(Trap, this.transform.GetChild(i).transform.position, Quaternion.identity);
                    obj2.transform.parent = this.transform;
                    what = false;
                    break;
                }
                else
                {
                    what = true;
                }
            }
            if (what == true)
            {
                GameObject obj = Instantiate(Bomb, this.transform.GetChild(i).transform.position, Quaternion.identity);
                obj.transform.parent = this.transform;
            }
        }
    }
    
    public int[] GetRandomInt(int length, int min, int max)
    {
        randArray = new int[length];
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
