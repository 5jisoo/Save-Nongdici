using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    // 현재 스테이지 - 각 스테이지마다 미리 조정해두기.
    public int stageCheck;

    public bool gameStart;
    public int score;
    public GameObject scoreController;
    public GameObject stageClearWindow;

    private int currentScore;
    private Animator thisAnim;

    // Start is called before the first frame update
    void Start()
    {
        gameStart = false;
        thisAnim = stageClearWindow.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentScore = scoreController.GetComponent<ScoreController>().totalscore;
        if (currentScore >= 50)
        {
            stageClear();
        }
    }

    void stageClear()
    {
        thisAnim.SetBool("clear", true);
    }
}
