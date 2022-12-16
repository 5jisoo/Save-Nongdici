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

    // 만약 진행중이라 true면 setActive하지 못하게 막아야함.
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

            // 가로로 이동중일 때 + 수확애니메이션 끝나면

            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                sidePlayer.transform.rotation = Quaternion.Euler(0, 0, 0);
                if ((currentAnimState = frontPlayer.GetComponent<PlayerContoller>().isAnimating ) == false)
                {
                    frontPlayer.SetActive(false);
                    sidePlayer.SetActive(true);
                    if (Input.GetAxisRaw("Horizontal") < 0) //왼쪽으로 이동
                    {
                        moveVelocity = Vector3.left;
                    }
                    else if (Input.GetAxisRaw("Horizontal") > 0) //오른쪽으로 이동
                    {
                        moveVelocity = Vector3.right;
                    }
                }
            }


            // 세로로 이동중일 때
            else if (Input.GetAxisRaw("Vertical") != 0)
            {
                sidePlayer.SetActive(false);
                frontPlayer.SetActive(true);
                if (Input.GetAxisRaw("Vertical") < 0) //아래로 이동
                {
                    moveVelocity = Vector3.down;
                }
                else if (Input.GetAxisRaw("Vertical") > 0) //위로 이동
                {
                    moveVelocity = Vector3.up;
                }
            }

            else                                            // 가만히 있을 때 + 애니메이션이 끝났을 때
            {
                sidePlayer.SetActive(false);
                frontPlayer.SetActive(true);
            }

            currentPosition.position += moveVelocity * speed * Time.deltaTime;

            // 카메라 밖으로 못나가게 막아버림
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
        // 애니메이션이 끝났는지 확인 필요
        sidePlayer.SetActive(false);
        frontPlayer.SetActive(true);    // frontPlayer가 움직일 수 있도록.

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
