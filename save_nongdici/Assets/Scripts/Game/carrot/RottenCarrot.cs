using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� ���
public class RottenCarrot : MonoBehaviour
{
    private Vector3 thisPosition;

    public GameObject playerStateController;
    public GameObject scoreController;
    

    public Transform playerPosition;
    public Vector3 playerVectorPosition;

    public float distance;

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
            scoreController.GetComponent<ScoreController>().totalscore -= 5;
            print("���� ��� ��Ȯ!");
            Destroy(gameObject);
        }

    }
}