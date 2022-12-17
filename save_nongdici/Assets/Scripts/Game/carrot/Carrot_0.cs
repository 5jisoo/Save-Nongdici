using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 제일 건강한 당근
public class Carrot_0 : MonoBehaviour
{

    private Vector3 thisPosition;

    public GameObject gameSystem;
    public GameObject inventorySystem;
    public GameObject playerStateController;
    public GameObject scoreController;
    public GameObject GetCarrots;

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
        currentStageScore = 11 - gameSystem.GetComponent<GameSystem>().stageCheck;
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
        // print("거리 계산 완료" + distance);

        if (distance <= 2.0f)
        {
            playerStateController.GetComponent<PlayerStateController>().isHarvesting(currentItem);
            if (currentItem != 0)
            {
                scoreController.GetComponent<ScoreController>().totalscore += (currentStageScore - 13);
                print("도구 선택 오류!");
                GetCarrots.GetComponent<GetCarrots>().isHarvested(4, thisPosition);
            }
            else
            {
                scoreController.GetComponent<ScoreController>().totalscore += currentStageScore;
                print("정상 적인 수확!");
                GetCarrots.GetComponent<GetCarrots>().isHarvested(2, thisPosition);
            }
            isObjectDestroyed = true;
            Destroy(gameObject);
        }

    }

}
