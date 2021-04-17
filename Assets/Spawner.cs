using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float spawnTime;
    private float defaultSpawnTime;
    public GameObject [] enemiesGO;
    public Transform[] spawnPos;
    private void Awake()
    {
        spawnTime = defaultSpawnTime;
    }

    void Start()
    {
        
    }

    void Update()
    {
        //Decrease defaultSpawnTime after certain time



        if(spawnTime <= 0)
        {
            //SpawnEnemy
            spawnEnemy();
        }
        spawnTime -= Time.deltaTime;
        
    
    }

    void spawnEnemy()
    {
        GameObject enemy = Instantiate(enemiesGO[Random.Range(0, enemiesGO.Length)], spawnPos[Random.Range(0, spawnPos.Length)].position, Quaternion.identity);
        spawnTime = defaultSpawnTime;

    }


}
