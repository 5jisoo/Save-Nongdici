using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class click_skip : MonoBehaviour
{
    public void SceneSKIP()
    {
        SceneManager.LoadScene("3_ChooseName");
    }
}
