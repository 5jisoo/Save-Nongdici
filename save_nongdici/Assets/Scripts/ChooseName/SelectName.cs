using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectName : MonoBehaviour
{
    public GameObject Player;
    public Text text;
    public PlayerData playerData;
    public bool nameChecked = false;

    void Start()
    {
        playerData = Player.GetComponent<PlayerContoller>().playerData;
    }

    public void selectName()
    {
        nameChecked = true;
        if (nameChecked)
        {
            playerData.name = text.text;
            Player.GetComponent<PlayerContoller>().SavePlayerDataToJson();
            print("저장완료");
        }

    }
}
