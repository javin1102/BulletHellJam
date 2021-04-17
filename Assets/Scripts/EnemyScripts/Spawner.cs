using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float time;
    public float spawnTime = 7;
    private float defaultSpawnTime;
    public GameObject [] enemiesGO;
    public Transform[] spawnPos;


    private void Awake()
    {
        defaultSpawnTime = spawnTime;
    }

    void Start()
    {
        
    }

    void Update()
    {
        //Untuk Kenzie (please code yourself) : Decrease defaultSpawnTime after certain time 
        time += Time.deltaTime;
        //Count Time
        if (time >= 5)
        {
            defaultSpawnTime -= 1;
            time = 0;
        }

        if (defaultSpawnTime <= 2)
            defaultSpawnTime = 2;

            

         


        if(spawnTime <= 0)
        {
            print("asasas");
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
