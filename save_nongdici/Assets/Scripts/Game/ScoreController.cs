using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{

    public GameObject playerStateController;
    public Transform currentPosition;

    public Text scoreTxt;

    public int totalscore;

    // Start is called before the first frame update
    void Start()
    {
        totalscore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        string scoreString = "Score ; " + totalscore.ToString();
        scoreTxt.text = scoreString;
    }

}
