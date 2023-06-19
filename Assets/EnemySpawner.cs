using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 5f;
    public float spawnDelay = 2f;
    public int nrEnemy = 2;
    public FinalBossSpawner finalBossSpawner;

    private void Start()
    {
        finalBossSpawner = FindObjectOfType<FinalBossSpawner>();

        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(spawnDelay);

        while (nrEnemy > 0)
        {
            GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.Euler(0f, 180f, 0f));

            yield return new WaitForSeconds(spawnRate);

            nrEnemy--;
        }

        yield return StartCoroutine(finalBossSpawner.SpawnEnemies());
    }
}