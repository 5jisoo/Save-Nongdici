using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    // ���� �������� - �� ������������ �̸� �����صα�.
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
        clearScore = stageCheck*50;    
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
