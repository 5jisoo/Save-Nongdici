using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameBtn : MonoBehaviour
{
    public Animator anim;

    public void Start()
    {
        anim.SetBool("CharacClick", false);
    }

    public void SceneChange()
    {
        SceneManager.LoadScene("2_Intro");
    }

    public void ClickPlayer()
    {
        anim.SetBool("CharacClick", true);
        print("PlayerClick");
        Invoke("ClickPlayerReset", 0.4f);
    }

    public void ClickPlayerReset()
    {
        anim.SetBool("CharacClick", false);
    }
}
