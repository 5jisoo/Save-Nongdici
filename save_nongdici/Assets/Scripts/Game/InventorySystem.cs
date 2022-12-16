using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    // 장갑 - 호미 - 낫
    public GameObject[] frontPlayerItems;

    public GameObject[] sidePlayerItems;
    public GameObject sideRightGlove;   // 오른쪽 장갑 따로 설정필요

    public GameObject inventory;
    private Animator invenAnim;

    // 현재 아이템 인덱스 확인 : 초기 = 장갑
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
            point %= 3;                 // 다시 돌아오기 위해
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            point--;
            point = (point + 3) % 3;    // 다시 돌아오기 위해
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
