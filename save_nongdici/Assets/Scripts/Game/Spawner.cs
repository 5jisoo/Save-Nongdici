using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject GameSystem;
    public GameObject scoreController;

    public bool[] spawnCheck;
    public int randomPoints;
    public Transform[] spawnPoints;
    public GameObject[] carrots;

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
        spawnCheck = new bool[11];
        for (int i=0; i<11; i++)
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

                StartCoroutine(grow1(clone, randomSpawnPoint.position, randomPoints));

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
    IEnumerator grow1(GameObject clone, Vector3 position, int point)
    {
        float randomGrowTime = Random.Range(1, 3);
        yield return new WaitForSeconds(randomGrowTime);

        try
        {
            isObjectDestroyed = clone.GetComponent<Carrot_2>().isObjectDestroyed;

            Destroy(clone);

            Vector3 vector = position;
            vector.x += 0.07f;
            vector.y += 0.43f;

            var clone2 = Instantiate(carrots[1], vector, Quaternion.identity);
            clone2.SetActive(true);

            StartCoroutine(grow2(clone2, vector, point));

        }
        catch(MissingReferenceException e)
        {
            spawnCheck[point] = false;

            // print("새싹 이후 grow 중단 시킴");
        }
        
    }


    // 덜 자란 당근 -> 다 자란 당근
    IEnumerator grow2(GameObject clone, Vector3 position, int point)
    {
        float randomGrowTime = Random.Range(1, 3);
        yield return new WaitForSeconds(randomGrowTime);

        try
        {
            isObjectDestroyed = clone.GetComponent<Carrot_1>().isObjectDestroyed;

            Destroy(clone);

            Vector3 vector = position;
            vector.x -= 0.1f;
            vector.y += 0.32f;

            var clone2 = Instantiate(carrots[2], vector, Quaternion.identity);
            clone2.SetActive(true);

            StartCoroutine(grow3(clone2, vector, point));

        }
        catch(MissingReferenceException e)
        {
            spawnCheck[point] = false;
            // print("덜 자란 당근 이후 grow 중단 시킴");
        }

    }


    // 다 자란 당근 -> 썩은 당근
    IEnumerator grow3(GameObject clone, Vector3 position, int point)
    {
        float randomGrowTime = Random.Range(2, 3);
        yield return new WaitForSeconds(randomGrowTime);

        try
        {
            isObjectDestroyed = clone.GetComponent<Carrot_0>().isObjectDestroyed;

            Destroy(clone);

            Vector3 vector = position;
            vector.y -= 0.45f;

            var clone2 = Instantiate(carrots[3], vector, Quaternion.identity);
            clone2.SetActive(true);

            scoreController.GetComponent<ScoreController>().totalscore -= 3;    // 작물이 썩은 경우

            Destroy(clone2, .5f);
            spawnCheck[point] = false;

        } catch(MissingReferenceException e)
        {
            spawnCheck[point] = false;
            // print("전부 자란 당근 이후 grow 중단 시킴"); //확인 완
        }

       
    }
}
