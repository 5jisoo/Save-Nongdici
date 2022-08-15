using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    public GameObject frontPlayer;
    public GameObject sidePlayer;
    public GameObject gameSystem;

    public float speed;
    private float inputHorizontal, inputVertical;

    public bool gameStart;

    public Transform currentPosition;

    

    Rigidbody2D rb;
    Animator frontAnim, sideAnim;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        frontAnim = frontPlayer.GetComponent<Animator>();
        sideAnim = sidePlayer.GetComponent<Animator>();
        currentPosition = frontPlayer.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputHorizontal == 0)
        {
            frontPlayer.SetActive(true);
            sidePlayer.SetActive(false);
        }
        else
        {
            frontPlayer.SetActive(false);
            sidePlayer.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        gameStart = gameSystem.GetComponent<GameSystem>().gameStart;
        if (gameStart)
        {
            frontAnim.SetBool("gameStart", true);
            inputHorizontal = Input.GetAxisRaw("Horizontal");
            inputVertical = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(speed * inputHorizontal, speed * inputVertical);
        }
        else
        {
            frontAnim.SetBool("gameStart", false);
        }
    }
}
