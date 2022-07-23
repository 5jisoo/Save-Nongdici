using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSystem : MonoBehaviour
{
    public GameObject GameSystem;
    public GameObject howToPlay;

    public void skipHowToPlay()
    {
        howToPlay.SetActive(false);
    }
    
}
