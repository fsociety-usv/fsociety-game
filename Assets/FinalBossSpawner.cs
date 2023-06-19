using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class FinalBossSpawner : MonoBehaviour
{
    public GameObject bossPrefab;
    public float spawnDelay = 2f;

    public Transform player;

    public IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(spawnDelay);

        GameObject finalBoss = Instantiate(bossPrefab, transform.position, Quaternion.Euler(0f, 180f, 0f));

        finalBoss.GetComponent<FinalBoss>().isFlipped = true;
    }
}