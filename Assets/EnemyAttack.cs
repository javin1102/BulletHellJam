using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject bulletPrefab;
    private EnemyMovement enemyMovement;
    public Transform firePos;
    public float fireRate;
    private float bulletDistance = 2f;
    private float defaultFireRate;
    

    private void Awake()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        defaultFireRate = fireRate;
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (enemyMovement.playerGO == null) return;

        //attack Player if in Range
        if (fireRate <=0)
        {
            fireRate = defaultFireRate;
            spawnBullet();
        }
        fireRate -= Time.deltaTime;
    }

    private void spawnBullet()
    {

        GameObject bullet = Instantiate(bulletPrefab, firePos.position, transform.rotation);
        Destroy(bullet, bulletDistance);
    }


}
