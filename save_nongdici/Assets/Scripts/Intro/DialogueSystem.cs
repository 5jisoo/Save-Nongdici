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

    public Queue<string> sentences = new Queue<string>();

    public void Start()
    {
        LoadPlayerDataFromJson();
        anim.SetBool("isClose", false);
        // Begin(info);
        DialogueSystem system = FindObjectOfType<DialogueSystem>();    //�ý��ۿ� ����
        system.Begin(info);     //����ִ� ������ Begin�� ��������. -> �׷��� DialogueSystem.cs�� �ִ� Begin�� ���۵�.
    }

    public void Begin(Dialogue info)
    {
        info.sentences.Clear();
        sentences.Clear();

        if (setAnim)    //2
        {
            info.name = "???";
            txtName.text = info.name;
            info.sentences.Add("�ȳ� ���� ???(��)��!");
            info.sentences.Add("�� �� �̸��� �� �Ⱥ��̳�?");
            info.sentences.Add("�̷�...");
            info.sentences.Add("�� �̸���...");
        }
        else            // 3.5
        {
            txtName.text = playerName;
            info.sentences.Add($"�׷�. �� �̸��� {playerName}. ");
            info.sentences.Add("���� ���ġ ������ ������ �İ��ھ�.");
            info.sentences.Add("���� ������ �İ��ڰ� �Ǳ� ���ؼ�,");
            info.sentences.Add("�� �ɷ��� �����ؾ���!");
            info.sentences.Add("���� �����ٷ�?");
        }
        

        foreach (var sentence in info.sentences)
        {
            sentences.Enqueue(sentence);
        }

        Next();
    }

    public void Next()
    {
        if (setAnim)    //2
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
        else if (setAnim == false && sentences.Count == 0)  //3.5
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
            /*btnSkip�� ���� GameObject�� ���� ��� null�� ��ȯ�� �� ����.*/
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
        string jsonData = File.ReadAllText(Application.streamingAssetsPath + "/JsonFiles/playerData.json");
        playerData = JsonUtility.FromJson<PlayerData>(jsonData);
        
        playerName = playerData.name;
        Debug.Log("�÷��̾� ������ �ҷ����� �Ϸ�");
    }
}

[System.Serializable] //��ü�� �����ϴ� �뵵��.
public class Dialogue
{
    public string name;
    public List<string> sentences = new List<string>();
}


