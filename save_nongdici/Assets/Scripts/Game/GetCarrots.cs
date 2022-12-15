using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCarrots : MonoBehaviour
{

    // 순서대로 새싹 - 어린 - 건강 - 썩은
    public GameObject[] getCarrots;
    private Animator[] anims = new Animator[4];

    // Start is called before the first frame update
    void Start()
    {
        anims[0] = getCarrots[0].GetComponent<Animator>();
        anims[1] = getCarrots[1].GetComponent<Animator>();
        anims[2] = getCarrots[2].GetComponent<Animator>();
        anims[3] = getCarrots[3].GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void isHarvested(int num, Vector3 carrotPos)
    {
        carrotPos.y += 1;
        getCarrots[num].transform.position = carrotPos;
        getCarrots[num].SetActive(true);
        anims[num].SetBool("isHarvested", true);
        StartCoroutine(setBack(num));
    }

    IEnumerator setBack(int num) {

        yield return new WaitForSeconds(1f);
        anims[num].SetBool("isHarvested", false);
    }

}
