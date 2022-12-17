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
    private int clearScore;
    private Animator clearAnim;

    // Start is called before the first frame update
    void Start()
    {
        gameStart = false;
        clearAnim = stageClearWindow.GetComponent<Animator>();
        clearScore = stageCheck;    // 잠깐 테스트용 - 조정해야함
    }

    // Update is called once per frame
    void Update()
    {
        currentScore = scoreController.GetComponent<ScoreController>().totalscore;
        if (currentScore >= clearScore)
        {
            stageClear();
        }
    }

    void stageClear()
    {
        gameStart = false;
        clearAnim.SetBool("clear", true);
    }
}
