using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidePlayerMove : MonoBehaviour
{

    public GameObject playerStateController;
    public GameObject playerController;
    public Transform currentPosition;

    Animator sideAnim;
    Animator frontAnim;

    // Start is called before the first frame update
    void Start()
    {
        sideAnim = GetComponent<Animator>();
        frontAnim = playerController.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = playerStateController.GetComponent<PlayerStateController>().currentPosition;
        transform.position = currentPosition.position;

        if (Input.GetAxisRaw("Horizontal") > 0) //move right
        {
            sideAnim.SetBool("walkLeft", false);
            sideAnim.SetBool("walkRight", true);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0) //move left
        {
            //sidePlayer.transform.rotation = Quaternion.Euler(0, 0, 0);
            sideAnim.SetBool("walkRight", false);
            sideAnim.SetBool("walkLeft", true);
        }
        
    }
}
