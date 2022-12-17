using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject GameSystem;
    public GameObject scoreController;

    // 현재 스테이지
    public int currentStage;

    public bool[] spawnCheck;
    public int randomPoints;
    public Transform[] spawnPoints;

    // 생성할 아이템
    public GameObject[] carrots;
    public GameObject[] sweetPotato;
    public GameObject[] rice;

    public float timeSpawns;
    public float startSpawnTime;
    public float minTimeBtwSpawns;
    public float decrease;

    private Transform ex_randomSpawn;

    public bool GameStart;

    public bool isObjectDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        currentStage = GameSystem.GetComponent<GameSystem>().stageCheck;
        spawnCheck = new bool[11];
        for (int i = 0; i < 11; i++)
        {
            spawnCheck[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameStart = GameSystem.GetComponent<GameSystem>().gameStart;
        if (GameStart)
        {
            if (timeSpawns <= 0)
            {
                randomPoints = Random.Range(0, spawnPoints.Length);

                while (spawnCheck[randomPoints] == true)
                {
                    randomPoints = Random.Range(0, spawnPoints.Length);
                }

                var randomSpawnPoint = spawnPoints[randomPoints];

                var clone = Instantiate(carrots[0], randomSpawnPoint.position, Quaternion.identity);
                clone.SetActive(true);
                spawnCheck[randomPoints] = true;

                // 스테이지에 따른 작물 랜덤 선택 (당근 - 고구마 - 벼)
                int randomCrop = Random.Range(1, currentStage + 1);
                StartCoroutine(grow1(clone, randomSpawnPoint.position, randomPoints, randomCrop));


                if (startSpawnTime > minTimeBtwSpawns)
                {
                    startSpawnTime -= decrease;
                }

                timeSpawns = startSpawnTime;
            }
            else
            {
                timeSpawns -= Time.deltaTime;
            }
        }
    }


    // 새싹 -> 덜 자란 당근
    IEnumerator grow1(GameObject clone, Vector3 position, int point, int cropType)
    {
        float randomGrowTime = Random.Range(1, 3);
        yield return new WaitForSeconds(randomGrowTime);

        if ((bool)clone)
        {
            // 오브젝트가 살아있을 경우
            Destroy(clone);

            Vector3 vector = position;
            vector.x += 0.07f;
            vector.y += 0.43f;

            GameObject clone2;

            if (cropType == 1)
            {
                clone2 = Instantiate(carrots[1], vector, Quaternion.identity);
                clone2.SetActive(true);
            }
            else if (cropType == 2)
            {
                clone2 = Instantiate(sweetPotato[1], vector, Quaternion.identity);
                clone2.SetActive(true);
            }
            else
            {
                vector.x -= 0.2f;
                vector.y -= 0.2f;
                clone2 = Instantiate(rice[1], vector, Quaternion.identity);
                clone2.SetActive(true);
            }

            StartCoroutine(grow2(clone2, vector, point, cropType));
        }
        else
        {
            // 오브젝트가 이미 수확된 경우.
            spawnCheck[point] = false;

            // print("새싹 이후 grow 중단 시킴");
        }
    }


    // 덜 자란 당근 -> 다 자란 당근
    IEnumerator grow2(GameObject clone, Vector3 position, int point, int cropType)
    {
        float randomGrowTime = Random.Range(1, 3);
        yield return new WaitForSeconds(randomGrowTime);

        if((bool)clone)
        {
            // 아직 수확 안됨
            Destroy(clone);

            Vector3 vector = position;
            vector.x -= 0.1f;
            vector.y += 0.32f;

            GameObject clone2;

            if (cropType == 1)
            {
                clone2 = Instantiate(carrots[2], vector, Quaternion.identity);
                clone2.SetActive(true);
            }
            else if (cropType == 2)
            {
                vector.x -= 0.3f;
                clone2 = Instantiate(sweetPotato[2], vector, Quaternion.identity);
                clone2.SetActive(true);
            }
            else
            {
                vector.x += 0.4f;
                vector.y += 0.2f;
                clone2 = Instantiate(rice[2], vector, Quaternion.identity);
                clone2.SetActive(true);
            }

            StartCoroutine(grow3(clone2, vector, point, cropType));

        }
        else
        {
            // 수확 됨
            spawnCheck[point] = false;

            // print("덜 자란 작물 이후 grow 중단 시킴");
        }

    }


    // 다 자란 당근 -> 썩은 당근
    IEnumerator grow3(GameObject clone, Vector3 position, int point, int cropType)
    {
        float randomGrowTime = Random.Range(2, 3);
        yield return new WaitForSeconds(randomGrowTime);

        if ((bool) clone)
        {
            // isObjectDestroyed = clone.GetComponent<Carrot_0>().isObjectDestroyed;

            Destroy(clone);

            Vector3 vector = position;
            vector.y -= 0.45f;

            GameObject clone2;

            if (cropType == 1)
            {
                clone2 = Instantiate(carrots[3], vector, Quaternion.identity);
                clone2.SetActive(true);
            }
            else if (cropType == 2)
            {
                vector.x += 0.3f;
                vector.y -= 0.2f;
                clone2 = Instantiate(sweetPotato[3], vector, Quaternion.identity);
                clone2.SetActive(true);
            }
            else
            {
                vector.x -= 0.2f;
                vector.y +=0.1f;
                clone2 = Instantiate(rice[3], vector, Quaternion.identity);
                clone2.SetActive(true);
            }

            scoreController.GetComponent<ScoreController>().totalscore -= 3;    // 작물이 썩은 경우

            Destroy(clone2, .5f);
            spawnCheck[point] = false;

        }
        else
        {
            spawnCheck[point] = false;
            
            // print("전부 자란 작물 이후 grow 중단 시킴"); //확인 완
        }


    }
}
