using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class PlayerContoller : MonoBehaviour
{
    public PlayerData playerData;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class PlayerData
{
    public string name;
    public int score = 0;
}
