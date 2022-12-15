using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//货较
public class Carrot_2 : MonoBehaviour
{
    private Vector3 thisPosition;

    public GameObject playerStateController;
    public GameObject scoreController;
    public GameObject GetCarrots;

    public Transform playerPosition;
    public Vector3 playerVectorPosition;

    public float distance;

    public bool isObjectDestroyed = false;

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
    }

    private void OnMouseDown()
    {
        distance = Vector2.Distance(thisPosition, playerVectorPosition);

        if (distance <= 2.0f)
        {
            scoreController.GetComponent<ScoreController>().totalscore -= 3;
            print("货较 荐犬!");
            GetCarrots.GetComponent<GetCarrots>().isHarvested(0, thisPosition);
            isObjectDestroyed = true;
            Destroy(gameObject);
        }

    }
}
