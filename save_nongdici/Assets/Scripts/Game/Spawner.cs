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
    private Transform randomSpawnPoint;

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

                randomSpawnPoint = spawnPoints[randomPoints];

                var vector = randomSpawnPoint.position;
                vector.x += 0.28f;
                vector.y -= 0.04f;
                randomSpawnPoint.position = vector;

                var clone = Instantiate(carrots[0], randomSpawnPoint.position, Quaternion.identity);
                clone.SetActive(true);
                spawnCheck[randomPoints] = true;

                StartCoroutine(grow1(clone, randomSpawnPoint));

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

    IEnumerator grow1(GameObject clone, Transform position)
    {
        float randomGrowTime = Random.Range(1, 3);
        yield return new WaitForSeconds(randomGrowTime);

        Destroy(clone);

        var vector = position.position;
        vector.x += 0.07f;
        vector.y += 0.43f;
        position.position = vector;

        var clone2 = Instantiate(carrots[1], position.position, Quaternion.identity);
        clone2.SetActive(true);

        StartCoroutine(grow2(clone2, position));
    }

    IEnumerator grow2(GameObject clone, Transform position)
    {
        float randomGrowTime = Random.Range(1, 3);
        yield return new WaitForSeconds(randomGrowTime);

        Destroy(clone);

        var vector = position.position;
        vector.x -= 0.1f;
        vector.y += 0.32f;
        position.position = vector;

        var clone2 = Instantiate(carrots[2], position.position, Quaternion.identity);
        clone2.SetActive(true);

    }
}
