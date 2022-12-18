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
        Begin(info);     //들고있는 정보를 Begin에 전달해줌. -> 그러면 DialogueSystem.cs에 있는 Begin이 시작됨.
    }

    public void Begin(Dialogue info)
    {
        info.sentences.Clear();
        sentences.Clear();

        // txtName.text = playerName;
        info.sentences.Add($"그렇게 {playerName}은(는) 무사히 농디치 가문의 후계자가 될 수 있었다. ");
        info.sentences.Add("~Happy Ending~");
        info.sentences.Add($"{playerName}이(가) 놓친 작물의 개수는?");
        info.sentences.Add($"썩어버린 작물의 개수: {rottenCrops}");
        info.sentences.Add($"새싹을 뽑아버린 작물의 개수: {sprout}");
        info.sentences.Add($"덜 자랐는데 뽑아버린 작물의 개수: {youngCrops}");

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
            score.text = $"썩어버린 작물: {rottenCrops} \n" +
                $"새싹을 뽑아버린 작물의 개수: {sprout} \n" +
                $"덜 자랐는데 뽑아버린 작물의 개수: {youngCrops} \n\n" +
                $"게임 플레이해주셔서 감사합니다";

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

        Debug.Log("플레이어 데이터 불러오기 완료");
    }
}
