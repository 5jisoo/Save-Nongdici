using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ω‚¿∫ ¥Á±Ÿ
public class RottenCarrot : MonoBehaviour
{
    private Vector3 thisPosition;

    public GameObject inventorySystem;
    public GameObject playerStateController;
    public GameObject scoreController;
    public GameObject GetCarrots;


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
        distance = Vector2.Distance(thisPosition, playerVectorPosition);

        if (distance <= 2.0f)
        {
            // scoreController.GetComponent<ScoreController>().totalscore -= 5;
            print("Ω‚¿∫ ¥Á±Ÿ ºˆ»Æ!");
            GetCarrots.GetComponent<GetCarrots>().isHarvested(3, thisPosition);
            Destroy(gameObject);
        }

    }
}
