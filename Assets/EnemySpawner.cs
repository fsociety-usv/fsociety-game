using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab-ul inamicului
    public float spawnRate = 2f; // Ritmul de spawn al inamicilor
    public float spawnDelay = 2f; // Întârziere inițială înainte de a începe spawn-ul
    public Quaternion initialRotation; // Rotirea inițială a inamicului
    private Transform playerTransform;

    private void Start()
    {
        //var playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        // Începe un co-rutină care va genera inamici
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(spawnDelay);

        while (true)
        {
            GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.Euler(0f, 180f, 0f));
            //enemy.transform.rotation = playerTransform.rotation;
            

            yield return new WaitForSeconds(spawnRate);
        }
    }
}