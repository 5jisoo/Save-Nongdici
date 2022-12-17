using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notice : MonoBehaviour
{
    public GameObject gameSystem;
    public Text cnt;
    int count = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void counting()
    {
        if (count == 1)
        {
            cnt.text = "Start!!";
        }
        else
        {
            count--;
            cnt.text = count + "";
        }
    }

    public void countingFinish()
    {
        gameSystem.GetComponent<GameSystem>().gameStart = true;
    }
}
