using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class PlayerName : MonoBehaviour
{
    public PlayerData playerData;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    [ContextMenu("To Json Data")]
    public void SavePlayerDataToJson()
    {
        string jsonData = JsonUtility.ToJson(playerData, true);
        File.WriteAllText(Application.dataPath + "/JsonFiles/playerData.json", jsonData);
    }

    [ContextMenu("From Json Data")]
    public void LoadPlayerDataFromJson()
    {
        string jsonData = File.ReadAllText(Application.dataPath + "/JsonFiles/playerData.json");
        playerData = JsonUtility.FromJson<PlayerData>(jsonData);
    }
}

[System.Serializable]
public class PlayerData
{
    public string name;
    public int score = 0;
}

