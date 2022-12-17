using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YoungRice : MonoBehaviour
{
    private Vector3 thisPosition;

    public GameObject gameSystem;
    public GameObject inventorySystem;
    public GameObject playerStateController;
    public GameObject scoreController;
    public GameObject GetRice;

    public Transform playerPosition;
    public Vector3 playerVectorPosition;

    public float distance;

    public bool isObjectDestroyed = false;

    private int currentItem;

    public int currentStageScore;

    // Start is called before the first frame update
    void Start()
    {
        thisPosition = this.gameObject.transform.position;
        currentStageScore = 4 - gameSystem.GetComponent<GameSystem>().stageCheck;
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = playerStateController.GetComponent<PlayerStateController>().currentPosition;
        playerVectorPosition = playerPosition.position;
        currentItem = inventorySystem.GetComponent<InventorySystem>().point;
    }

    private void OnMouseDown()
    {
        distance = Vector2.Distance(thisPosition, playerVectorPosition);
        print("distance 확인" + distance);

        if (distance <= 2.0f)
        {
            playerStateController.GetComponent<PlayerStateController>().isHarvesting(currentItem);
            if (currentItem != 2)
            {
                scoreController.GetComponent<ScoreController>().totalscore += (currentStageScore - 6);
                print("도구 선택 오류!");
                GetRice.GetComponent<GetRice>().isHarvested(4, thisPosition);
            }
            else
            {
                scoreController.GetComponent<ScoreController>().totalscore += currentStageScore;
                print("덜 큰 당근 수확!");
                GetRice.GetComponent<GetRice>().isHarvested(1, thisPosition);
            }
            isObjectDestroyed = true;
            Destroy(gameObject);
        }

    }
}
