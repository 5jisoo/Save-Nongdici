using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    public GameObject frontPlayer;
    public GameObject sidePlayer;
    public GameObject gameSystem;

    public Transform currentPosition;

    public float speed;

    public Animator frontanim;
    public Animator sideAnim;

    public bool gameStart;

    // ���� �������̶� true�� setActive���� ���ϰ� ���ƾ���.
    public bool currentAnimState;


    void Start()
    {
        frontPlayer.SetActive(true);
        sidePlayer.SetActive(false);

        frontanim = frontPlayer.GetComponent<Animator>();
        sideAnim = sidePlayer.GetComponent<Animator>();

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

            // ���η� �̵����� �� + ��Ȯ�ִϸ��̼� ������

            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                sidePlayer.transform.rotation = Quaternion.Euler(0, 0, 0);
                if ((currentAnimState = frontPlayer.GetComponent<PlayerContoller>().isAnimating ) == false)
                {
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
            }


            // ���η� �̵����� ��
            else if (Input.GetAxisRaw("Vertical") != 0)
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

            else                                            // ������ ���� �� + �ִϸ��̼��� ������ ��
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

    public void isHarvesting(int itemNum)
    {
        // �ִϸ��̼��� �������� Ȯ�� �ʿ�
        sidePlayer.SetActive(false);
        frontPlayer.SetActive(true);    // frontPlayer�� ������ �� �ֵ���.

        string s = "";
        if (itemNum == 0)
        {
            s = "harvestingGlove";

        }
        else if (itemNum == 1)
        {
            s = "harvestingHomi";
        }
        else if (itemNum == 2)
        {
            s = "harvestingSickle";
        }

        frontanim.SetTrigger(s);
    }
}
