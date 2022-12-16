using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCarrots : MonoBehaviour
{

    // 순서대로 새싹 - 어린 - 건강 - 썩은 - 도구 잘못 선택
    public GameObject[] getCarrots;
    private Animator[] anims = new Animator[5];

    // Start is called before the first frame update
    void Start()
    {
        anims[0] = getCarrots[0].GetComponent<Animator>();
        anims[1] = getCarrots[1].GetComponent<Animator>();
        anims[2] = getCarrots[2].GetComponent<Animator>();
        anims[3] = getCarrots[3].GetComponent<Animator>();
        anims[4] = getCarrots[4].GetComponent<Animator>();  // 잘못수확한 경우
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void isHarvested(int num, Vector3 carrotPos)
    {
        carrotPos.z -= 30;     // 위로 올라오게 하기
        // print(carrotPos);   // 확인용

        var clone = Instantiate(getCarrots[num], carrotPos, Quaternion.identity);   // spawn
        clone.SetActive(true);
        clone.GetComponent<Animator>().SetBool("isHarvested", true);

        StartCoroutine(setBack(num, clone));
    }

    IEnumerator setBack(int num, GameObject clone) {

        yield return new WaitForSeconds(0.4f);
        clone.GetComponent<Animator>().SetBool("isHarvested", false);
        clone.SetActive(false);
    }

}
