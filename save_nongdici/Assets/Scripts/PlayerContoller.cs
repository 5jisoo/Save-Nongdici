using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class PlayerContoller : MonoBehaviour
{
    public PlayerData playerData;


    public GameObject playerStateController;
    public Transform currentPosition;

    public float speed;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        currentPosition = playerStateController.GetComponent<PlayerStateController>().currentPosition;
        transform.position = currentPosition.position;
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            anim.SetBool("playerWalk", true);
        }
        else
        {
            anim.SetBool("playerWalk", false);
        }
    }


    [ContextMenu("To Json Data")]
    public void SavePlayerDataToJson()
    {
        string jsonData = JsonUtility.ToJson(playerData, true);
        string path = Path.Combine(Application.dataPath, "playerData.json");
        File.WriteAllText(path, jsonData);
    }

    [ContextMenu("From Json Data")]
    public void LoadPlayerDataFromJson()
    {
        string path = Path.Combine(Application.dataPath, "playerData.json");
        string jsonData =  File.ReadAllText(path);
        playerData = JsonUtility.FromJson<PlayerData>(jsonData);
    }

}

[System.Serializable]
public class PlayerData
{
    public string name;
    public int score = 0;
}
