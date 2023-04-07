using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> Enemies = new List<GameObject>();
    public float spawnRate = 5;

    private float x,y;
    private Vector3 spawnPos;

    void Start()
    {
        StartCoroutine(SpawnTestEnemy());
    }

    IEnumerator SpawnTestEnemy()
    {
        x = Random.Range(-5, 5);
        y = Random.Range(-5, 5);
        spawnPos.x += x;
        spawnPos.y += y;
        Instantiate(Enemies[0], spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(spawnRate);
        StartCoroutine(SpawnTestEnemy());
    }
}
