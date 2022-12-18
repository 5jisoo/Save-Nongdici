using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class DialogueSystem : MonoBehaviour
{
    public Text txtName;
    public Text txtSentence;
    public Dialogue info;
    public Animator anim;
    public Animator anim2;
    private string textSentence;

    public bool setAnim;

    public PlayerData playerData;
    private string playerName;

    Queue<string> sentences = new Queue<string>();

    public void Start()
    {
        LoadPlayerDataFromJson();
        anim.SetBool("isClose", false);
        var system = FindObjectOfType<DialogueSystem>();    //시스템에 접근
        system.Begin(info);     //들고있는 정보를 Begin에 전달해줌. -> 그러면 DialogueSystem.cs에 있는 Begin이 시작됨.
    }

    public void Begin(Dialogue info)
    {
        sentences.Clear();

        if (setAnim)
        {
            txtName.text = info.name;
        }
        else
        {
            txtName.text = playerName;
            info.sentences[0] = $"그래. 내 이름은 {playerName}. ";
        }
        

        foreach (var sentence in info.sentences)
        {
            sentences.Enqueue(sentence);
        }

        Next();
    }

    public void Next()
    {
        if (setAnim)
        {
            if (sentences.Count == 0)
            {
                anim2.SetBool("embarrased", false);
                End();
                return;
            }
            else if (sentences.Count == 1)
            {
                anim2.SetBool("head_tilt", false);
                // anim2.SetBool("embarrased", true);
            }
            else if (sentences.Count == 3)
            {
                anim2.SetBool("head_tilt", true);
            }
        }
        else if (setAnim == false && sentences.Count == 0)
        {
            End();
            return;
        }
        //txtSentence.text = sentences.Dequeue();
        textSentence = sentences.Dequeue();

        StartCoroutine(_typing());
    }

    private void End()
    {

        anim.SetBool("isClose", true);
        txtSentence.text = string.Empty;
        var btnSkip = GameObject.FindWithTag("btnSkip");
        if (btnSkip)
        {
            Destroy(btnSkip);
            Invoke("NextScene", 0.5f);
        }
        else
        {
            Debug.Log("No game object called wibble found");
            /*btnSkip을 가진 GameObject가 없을 경우 null이 반환될 수 있음.*/
        }

    }
    IEnumerator _typing()
    {
        for (int i = 0; i <= textSentence.Length; i++)
        {
            txtSentence.text = textSentence.Substring(0, i);

            yield return new WaitForSeconds(0.05f);
        }
    }

    private void NextScene()
    {
        if (setAnim)
        {
            SceneManager.LoadScene("3_ChooseName");
        }
        else
        {
            SceneManager.LoadScene("4_Stage1");
        }
        
    }

    [ContextMenu("From Json Data")]
    public void LoadPlayerDataFromJson()
    {
        string jsonData = File.ReadAllText(Application.dataPath + "/JsonFiles/playerData.json");
        playerData = JsonUtility.FromJson<PlayerData>(jsonData);
        
        playerName = playerData.name;
    }
}


