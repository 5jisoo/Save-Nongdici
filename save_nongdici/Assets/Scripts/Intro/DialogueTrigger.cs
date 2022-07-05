using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue info;

    public void Trigger()
    {
        var system = FindObjectOfType<DialogueSystem>();    //시스템에 접근
        system.Begin(info);     //들고있는 정보를 Begin에 전달해줌. -> 그러면 DialogueSystem.cs에 있는 Begin이 시작됨.

    }
}
