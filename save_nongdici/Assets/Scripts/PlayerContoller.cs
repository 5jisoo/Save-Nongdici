using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class PlayerContoller : MonoBehaviour
{
    public GameObject frontPlayer;
    public GameObject sidePlayer;
    public GameObject gameSystem;

    public PlayerData playerData;

    public float speed;
    private float inputHorizontal, inputVertical;

    Rigidbody2D rb, siderb;
    Animator frontAnim, sideAnim;

    public Transform currentPosition;

    public bool gameStart;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        siderb = sidePlayer.GetComponent<Rigidbody2D>();
        frontAnim = GetComponent<Animator>();
        sideAnim = sidePlayer.GetComponent<Animator>();
        currentPosition = frontPlayer.transform;
    }

    void Update()
    {
        if (inputHorizontal == 0 && inputVertical == 0)
        {
            frontAnim.SetBool("playerWalk", false);
            frontPlayer.SetActive(true);
            sidePlayer.SetActive(false);
        }
        else if (inputHorizontal !=0 && inputVertical == 0)
        {
            frontAnim.SetBool("playerWalk", true);
            frontPlayer.SetActive(false);
            sidePlayer.SetActive(true);
            if (inputHorizontal > 0) //moving right
            {
                sideAnim.SetBool("walkLeft", false);
                sideAnim.SetBool("walkRight", true);
            }
            else if (inputHorizontal < 0) //moving left
            {
                sideAnim.SetBool("walkRight", false);
                sideAnim.SetBool("walkLeft", true);
            }
        }
        else if (inputVertical != 0 && inputHorizontal==0)
        {
            frontAnim.SetBool("playerWalk", false);
            frontPlayer.SetActive(true);
            sidePlayer.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        print(inputHorizontal +"   /   "+ inputVertical); //È®ÀÎ¿ë

        gameStart = gameSystem.GetComponent<GameSystem>().gameStart;
        if (gameStart)
        {
            frontAnim.SetBool("gameStart", true);

            rb.velocity = new Vector2(speed * inputHorizontal, speed * inputVertical);
            siderb.velocity = new Vector2(speed * inputHorizontal, speed * inputVertical);
        }
        else
        {
            frontAnim.SetBool("gameStart", false);
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
