using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject GameSystem;

    public bool[] spawnCheck;
    public Transform[] spawnPoints;
    public GameObject[] carrots;

    public float timeSpawns;
    public float startSpawnTime;
    public float minTimeBtwSpawns;
    public float decrease;

    private Transform ex_randomSpawn;

    public bool GameStart;

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
                var randomPoints = Random.Range(0, spawnPoints.Length);
                
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

    IEnumerator grow1(GameObject clone, Vector3 position, int point)
    {
        float randomGrowTime = Random.Range(1, 3);
        yield return new WaitForSeconds(randomGrowTime);

        Destroy(clone);

        Vector3 vector = position;
        vector.x += 0.07f;
        vector.y += 0.43f;

        var clone2 = Instantiate(carrots[1], vector, Quaternion.identity);
        clone2.SetActive(true);

        StartCoroutine(grow2(clone2, vector, point));
    }

    IEnumerator grow2(GameObject clone, Vector3 position, int point)
    {
        float randomGrowTime = Random.Range(1, 3);
        yield return new WaitForSeconds(randomGrowTime);

        Destroy(clone);

        Vector3 vector = position;
        vector.x -= 0.1f;
        vector.y += 0.32f;

        var clone2 = Instantiate(carrots[2], vector, Quaternion.identity);
        clone2.SetActive(true);

        StartCoroutine(grow3(clone2, vector, point));

    }

    IEnumerator grow3(GameObject clone, Vector3 position, int point)
    {
        float randomGrowTime = Random.Range(2, 3);
        yield return new WaitForSeconds(randomGrowTime);

        Destroy(clone);

        Vector3 vector = position;
        vector.y -= 0.45f;

        var clone2 = Instantiate(carrots[3], vector, Quaternion.identity);
        clone2.SetActive(true);

        Destroy(clone2, .5f);

        spawnCheck[point] = false;
    }
}
