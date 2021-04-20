using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private float fireRate = 15f;
    [SerializeField] private float speed = 20f;

    [Header("Shooting Mechanic")]
    public Transform firePos;

    private float nextTimeToFire = 0f;


    void Start()
    {

    }

    void Update()
    {
        //Shoot
        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

    }

    void Shoot()
    {
        GameObject obj = ObjectPoolingManager.Instance.getProj();
        if (obj == null) return;
        obj.transform.position = firePos.position;
        obj.transform.rotation = firePos.rotation;
        obj.transform.localScale = new Vector3((float) 0.1824623, (float) 1.5638, 1);
        obj.GetComponent<Projectile>().projSpeed = speed;
        obj.SetActive(true);
    }
}
