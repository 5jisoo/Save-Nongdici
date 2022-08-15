using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    public GameObject frontPlayer;
    public GameObject sidePlayer;
    public GameObject gameSystem;

    public Transform currentPosition;

    public float speed;

    public Animator frontanim;

    public bool gameStart;


    void Start()
    {
        frontPlayer.SetActive(true);
        sidePlayer.SetActive(false);

        frontanim = frontPlayer.GetComponent<Animator>();

        currentPosition = frontPlayer.transform;
    }

    // Update is called once per frame
    void Update()
    {
        gameStart = gameSystem.GetComponent<GameSystem>().gameStart;

        if (gameStart)
        {
            frontanim.SetBool("gameStart", true);
            Vector3 moveVelocity = Vector3.zero;

            if (Input.GetAxisRaw("Horizontal") != 0)    // 가로로 이동중일때
            {
                frontPlayer.SetActive(false);
                sidePlayer.SetActive(true);
                if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    moveVelocity = Vector3.left;
                }
                else if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    moveVelocity = Vector3.right;
                }
            }

            else                                        // 세로로 이동중일때
            {
                sidePlayer.SetActive(false);
                frontPlayer.SetActive(true);
                if (Input.GetAxisRaw("Vertical") < 0)
                {
                    moveVelocity = Vector3.down;
                }
                else if (Input.GetAxisRaw("Vertical") > 0)
                {
                    moveVelocity = Vector3.up;
                }
            }

            currentPosition.position += moveVelocity * speed * Time.deltaTime;
        }
        else
        {
            frontanim.SetBool("gameStart", false);
        }

    }
}
