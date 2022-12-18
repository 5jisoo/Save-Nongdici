using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class EndingDialogue : MonoBehaviour
{
    public GameObject endingWindow;
    public Text score;
    
    public Text txtName;
    public Text txtSentence;
    public Dialogue info = new Dialogue();
    private string textSentence;

    public PlayerData playerData;
    private string playerName;
    private int rottenCrops;
    private int sprout;
    private int youngCrops;

    public Queue<string> sentences = new Queue<string>();

    public void Start()
    {
        LoadPlayerDataFromJson();
        Begin(info);     //����ִ� ������ Begin�� ��������. -> �׷��� DialogueSystem.cs�� �ִ� Begin�� ���۵�.
    }

    public void Begin(Dialogue info)
    {
        info.sentences.Clear();
        sentences.Clear();

        // txtName.text = playerName;
        info.sentences.Add($"�׷��� {playerName}��(��) ������ ���ġ ������ �İ��ڰ� �� �� �־���. ");
        info.sentences.Add("~Happy Ending~");
        info.sentences.Add($"{playerName}��(��) ��ģ �۹��� ������?");
        info.sentences.Add($"������ �۹��� ����: {rottenCrops}");
        info.sentences.Add($"������ �̾ƹ��� �۹��� ����: {sprout}");
        info.sentences.Add($"�� �ڶ��µ� �̾ƹ��� �۹��� ����: {youngCrops}");

        foreach (var sentence in info.sentences)
        {
            sentences.Enqueue(sentence);
        }

        Next();
    }

    public void Next()
    {
        if(sentences.Count == 0)
        {
            score.text = $"������ �۹�: {rottenCrops} \n" +
                $"������ �̾ƹ��� �۹��� ����: {sprout} \n" +
                $"�� �ڶ��µ� �̾ƹ��� �۹��� ����: {youngCrops} \n\n" +
                $"���� �÷������ּż� �����մϴ�";

            endingWindow.SetActive(true);
            return;
        }
        textSentence = sentences.Dequeue();
        StartCoroutine(_typing());
    }

    IEnumerator _typing()
    {
        for (int i = 0; i <= textSentence.Length; i++)
        {
            txtSentence.text = textSentence.Substring(0, i);

            yield return new WaitForSeconds(0.05f);
        }
    }


    [ContextMenu("From Json Data")]
    public void LoadPlayerDataFromJson()
    {
        string jsonData = File.ReadAllText(Application.streamingAssetsPath + "/JsonFiles/playerData.json");
        playerData = JsonUtility.FromJson<PlayerData>(jsonData);

        playerName = playerData.name;
        rottenCrops = playerData.rottenCrops;
        sprout = playerData.sprout;
        youngCrops = playerData.youngCrops;

        Debug.Log("�÷��̾� ������ �ҷ����� �Ϸ�");
    }
}
