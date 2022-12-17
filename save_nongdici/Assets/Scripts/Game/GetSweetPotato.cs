using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSweetPotato : MonoBehaviour
{
    // ������� ���� - � - �ǰ� - ���� - ���� �߸� ����
    public GameObject[] getSweets;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void isHarvested(int num, Vector3 sweetPos)
    {
        sweetPos.z -= 30;     // ���� �ö���� �ϱ�
        // print(carrotPos);   // Ȯ�ο�

        var clone = Instantiate(getSweets[num], sweetPos, Quaternion.identity);   // spawn
        clone.SetActive(true);
        clone.GetComponent<Animator>().SetBool("isHarvested", true);

        StartCoroutine(setBack(num, clone));
    }

    IEnumerator setBack(int num, GameObject clone)
    {

        yield return new WaitForSeconds(0.4f);
        clone.GetComponent<Animator>().SetBool("isHarvested", false);
        clone.SetActive(false);
    }
}
