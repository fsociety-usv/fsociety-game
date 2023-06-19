using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner2 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 5f;
    public float spawnDelay = 2f;
    public int nrEnemy = 5;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(spawnDelay);

        while (nrEnemy > 0)
        {
            GameObject enemy2 = Instantiate(enemyPrefab, transform.position, Quaternion.Euler(0f, 180f, 0f));

            enemy2.GetComponent<Boss>().isFlipped = true;

            yield return new WaitForSeconds(spawnRate);

            nrEnemy--;
        }
    }
}
