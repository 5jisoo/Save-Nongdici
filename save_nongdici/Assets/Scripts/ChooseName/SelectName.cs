using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectName : MonoBehaviour
{
    public GameObject Player;
    public Text text;

    public GameObject insertNamePlz;

    public GameObject confirmName;
    public Animator confirmNameAnim;
    public Text confirmNameTxt;

    public PlayerData playerData;



    void Start()
    {
        playerData = Player.GetComponent<PlayerContoller>().playerData;
        confirmNameAnim = confirmName.GetComponent<Animator>();
    }

    public void selectName()
    {
        if (text.text != "")
        {
            insertNamePlz.SetActive(false);
            playerData.name = text.text;
            Player.GetComponent<PlayerContoller>().SavePlayerDataToJson();
            print("저장완료");
            confirmNameTxt.text = "'" + playerData.name + "'" + " (으)로";
            confirmNameAnim.SetTrigger("SelectName");
        }
        else
        {
            insertNamePlz.SetActive(true);
        }
    }

    public void retryName()
    {
        SceneManager.LoadScene("3_ChooseName");
    }

    public void nameConfirm()
    {
        SceneManager.LoadScene("4_Stage1");
    }
}
