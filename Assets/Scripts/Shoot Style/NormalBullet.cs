using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private float fireRate = 15f;

    [Header("Shooting Mechanic")]
    public Transform firePos;


    [Header("Bullet")]
    public float projSpeed = 20f;

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
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        rb.AddForce(firePos.up * projSpeed, ForceMode2D.Impulse);
        obj.SetActive(true);
    }
}
