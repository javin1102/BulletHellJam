using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBullet : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private float fireRate = 1f;

    [Header("Shooting Mechanic")]
    public Transform firePos;

    

    private float nextTimeToFire = 0f;
    private int bulletAmount = 3;

    void Start()
    {

    }

    void Update()
    {


        //Shoot
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

    }

    void Shoot()
    {
        for(int i = 0; i < bulletAmount; i++)
        {
            GameObject obj = ObjectPoolingManager.Instance.getProj();
            if (obj == null) return;
            obj.transform.position = firePos.position;
            obj.transform.rotation = firePos.rotation;
            obj.transform.localScale = new Vector3((float)0.1824623, (float)1.5638, 1);
            obj.transform.Rotate(new Vector3(0, 0, firePos.rotation.z + Random.Range(-30, 30)));
            obj.GetComponent<Projectile>().projSpeed = 5f;
            obj.SetActive(true);
        }

    }
}
