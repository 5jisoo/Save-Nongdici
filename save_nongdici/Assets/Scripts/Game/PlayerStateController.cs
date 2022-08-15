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

            if (Input.GetAxisRaw("Horizontal") != 0 )    // ���η� �̵����� ��
            {
                sidePlayer.transform.rotation = Quaternion.Euler(0, 0, 0);
                frontPlayer.SetActive(false);
                sidePlayer.SetActive(true);
                if (Input.GetAxisRaw("Horizontal") < 0) //�������� �̵�
                {
                    moveVelocity = Vector3.left;
                }
                else if (Input.GetAxisRaw("Horizontal") > 0) //���������� �̵�
                {
                    moveVelocity = Vector3.right;
                }
            }

            else if (Input.GetAxisRaw("Vertical") != 0)   // ���η� �̵����� ��
            {
                sidePlayer.SetActive(false);
                frontPlayer.SetActive(true);
                if (Input.GetAxisRaw("Vertical") < 0) //�Ʒ��� �̵�
                {
                    moveVelocity = Vector3.down;
                }
                else if (Input.GetAxisRaw("Vertical") > 0) //���� �̵�
                {
                    moveVelocity = Vector3.up;
                }
            }

            else                                            // ������ ���� ��
            {
                sidePlayer.SetActive(false);
                frontPlayer.SetActive(true);
            }

            currentPosition.position += moveVelocity * speed * Time.deltaTime;

            // ī�޶� ������ �������� ���ƹ���
            Vector3 pos = Camera.main.WorldToViewportPoint(currentPosition.position);

            if (pos.x < 0f) pos.x = 0f;
            if (pos.x > 1f) pos.x = 1f;
            if (pos.y < 0f) pos.y = 0f;
            if (pos.y > 1f) pos.y = 1f;

            currentPosition.position = Camera.main.ViewportToWorldPoint(pos);

        }
        else
        {
            frontanim.SetBool("gameStart", false);
        }

    }
}
