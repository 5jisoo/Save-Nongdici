using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class typing_effect : MonoBehaviour
{
    public Text tx;
    private string m_text = "�츮 ���ġ ������ ���� ������ �Ұ��غ���!";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(_typing());
    }

    IEnumerator _typing()
    {
        for (int i = 0; i <= m_text.Length; i++)
        {
            tx.text = m_text.Substring(0, i);

            yield return new WaitForSeconds(0.1f);
        }
        Destroy(this);
    }
}
