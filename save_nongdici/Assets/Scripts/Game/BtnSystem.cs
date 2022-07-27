using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSystem : MonoBehaviour
{
    public GameObject GameSystem;
    public GameObject howToPlay;
    public Animator howToPlayAnim;

    public void Start()
    {
        howToPlayAnim = howToPlay.GetComponent<Animator>();
    }

    public void skipHowToPlay()
    {
        howToPlayAnim.SetTrigger("skip");
    }

    public void moveRight()
    {
        howToPlayAnim.SetTrigger("moveRight");
    }
    
    public void moveLeft()
    {
        howToPlayAnim.SetTrigger("moveLeft");
    }
}
