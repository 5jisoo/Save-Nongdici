using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnSystem_Clear : MonoBehaviour
{
    public GameObject gameSystem;

    private int currentStage;

    // Start is called before the first frame update
    void Start()
    {
        currentStage = gameSystem.GetComponent<GameSystem>().stageCheck;
    }

    // Update is called once per frame
    void Update()
    {
        currentStage = gameSystem.GetComponent<GameSystem>().stageCheck;
    }

    public void stageClear()
    {
        if(currentStage == 1)
        {
            SceneManager.LoadScene("5_Stage2");
        } else if(currentStage == 2)
        {
            SceneManager.LoadScene("6_Stage3");
        }
        else
        {
            SceneManager.LoadScene("Ending");
        }
    }
}
