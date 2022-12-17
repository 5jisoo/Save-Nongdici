using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RottenRice : MonoBehaviour
{
    private Vector3 thisPosition;

    public GameObject inventorySystem;
    public GameObject playerStateController;
    public GameObject getRice;


    public Transform playerPosition;
    public Vector3 playerVectorPosition;

    public float distance;

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
        playerStateController.GetComponent<PlayerStateController>().isHarvesting(currentItem);
        distance = Vector2.Distance(thisPosition, playerVectorPosition);

        if (distance <= 2.0f)
        {
            print("썩은 당근 수확!");
            getRice.GetComponent<GetRice>().isHarvested(3, thisPosition);
            Destroy(gameObject);
        }

    }
}
