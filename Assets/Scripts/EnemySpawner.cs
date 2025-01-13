using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemies;
    public GameObject[] spawnLocations;
    Entity entity;
    public List<GameObject> enemyList;

    void Start()
    {
        spawnLocations = GameObject.FindGameObjectsWithTag("EnemySpawn");
        EnemyScale();
        InvokeRepeating(nameof(SpawnEnemies), 0, 1);      
    }

    void SpawnEnemies()
    {
        Instantiate(enemies[Random.Range(0, enemies.Count)], spawnLocations[Random.Range(0, spawnLocations.Length)].transform.position, Quaternion.identity);
    }

    public void EnemyScale()
    {
        if (enemies.Contains(enemyList[0]))
        {
            enemyList.Remove(enemyList[0]);
            EnemyScale();
            return;
        }
        enemies.Add(enemyList[0]);
        enemyList.Remove(enemyList[0]);
    }
}

