using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllSideBullet : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float speed = 3f;

    [Header("Shooting Mechanic")]
    public Transform firePos;
    public int angle;



    private float nextTimeToFire = 0f;
    private int bulletAmount = 8;



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

        for (int i = 0; i < bulletAmount; i++)
        {

            GameObject obj = ObjectPoolingManager.Instance.getProj();
            if (obj == null) return;
            obj.transform.position = firePos.position;
            obj.transform.rotation = firePos.rotation;
            obj.transform.localScale = new Vector3((float)0.1824623, (float)1.5638, 1);
            obj.transform.Rotate(new Vector3(0, 0, firePos.rotation.z + i * angle));
            obj.GetComponent<Projectile>().projSpeed = speed;
            obj.SetActive(true);
        }

    }
}
