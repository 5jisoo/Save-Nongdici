using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    // �尩 - ȣ�� - ��
    public GameObject[] frontPlayerItems;

    public GameObject[] sidePlayerItems;
    public GameObject sideRightGlove;   // ������ �尩 ���� �����ʿ�

    public GameObject inventory;
    private Animator invenAnim;

    // ���� ������ �ε��� Ȯ�� : �ʱ� = �尩
    public int point = 0;

    // Start is called before the first frame update
    void Start()
    {
        invenAnim = inventory.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            point++;
            point %= 3;                 // �ٽ� ���ƿ��� ����
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            point--;
            point = (point + 3) % 3;    // �ٽ� ���ƿ��� ����
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            point = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            point = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            point = 2;
        }

        invenAnim.SetInteger("point", point);
        setVisible(point);

    }

    void setVisible(int point)
    {
        for(int i = 0; i < 3; i++)
        {
            if (i == point)
            {
                frontPlayerItems[i].SetActive(true);
                sidePlayerItems[i].SetActive(true);
                if(point == 0)
                {
                    sideRightGlove.SetActive(true);
                }
            }
            else
            {
                frontPlayerItems[i].SetActive(false);
                sidePlayerItems[i].SetActive(false);
            }
        }
    }
}
