using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnSystem : MonoBehaviour
{
    public GameObject GameSystem;
    public GameObject howToPlay;
    public Animator howToPlayAnim;

    public int currentStage;

    public void Start()
    {

        howToPlayAnim = howToPlay.GetComponent<Animator>();

    }

    public void skipHowToPlay()
    {

        howToPlayAnim.SetTrigger("skip");
        GameSystem.GetComponent<GameSystem>().gameStart = true;

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
