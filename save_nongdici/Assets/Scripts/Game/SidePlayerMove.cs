using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidePlayerMove : MonoBehaviour
{
    public GameObject sidePlayer;
    public GameObject playerStateController;
    public Transform currentPosition;

    public float speed;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = playerStateController.GetComponent<PlayerStateController>().currentPosition;
        transform.position = currentPosition.position;

        if (Input.GetAxisRaw("Horizontal") > 0) //move right
        {
            anim.SetBool("walkLeft", false);
            anim.SetBool("walkRight", true);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0) //move left
        {
            sidePlayer.transform.rotation = Quaternion.Euler(0, 0, 0);
            anim.SetBool("walkRight", false);
            anim.SetBool("walkLeft", true);
        }
        
    }
}
