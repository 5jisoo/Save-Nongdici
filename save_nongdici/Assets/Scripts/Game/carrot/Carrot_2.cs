using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����
public class Carrot_2 : MonoBehaviour
{
    private Vector3 thisPosition;

    public GameObject inventorySystem;
    public GameObject playerStateController;
    public GameObject scoreController;
    public GameObject GetCarrots;

    public Transform playerPosition;
    public Vector3 playerVectorPosition;

    public float distance;

    public bool isObjectDestroyed = false;

    private int currentItem;

    // Start is called before the first frame update
    void Start()
    {
        thisPosition = this.gameObject.transform.position;
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

        if (distance <= 2.0f)
        {
            if (currentItem != 0)
            {
                scoreController.GetComponent<ScoreController>().totalscore -= 3;
                print("���� ���� ����!");
                GetCarrots.GetComponent<GetCarrots>().isHarvested(4, thisPosition);
            }
            else
            {
                // scoreController.GetComponent<ScoreController>().totalscore -= 3; // ���� ���� ����
                print("���� ��Ȯ!");
                GetCarrots.GetComponent<GetCarrots>().isHarvested(0, thisPosition);
            }
            isObjectDestroyed = true;
            Destroy(gameObject);
        }

    }
}
