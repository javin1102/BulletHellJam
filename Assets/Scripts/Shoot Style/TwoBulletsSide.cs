using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoBulletsSide : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private float fireRate = 5f;

    [Header("Shooting Mechanic")]
    public Transform[] firePos = new Transform[2];


    [Header("Bullet")]
    public float projSpeed = 5f;

    private float nextTimeToFire = 0f;


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
        foreach(Transform firePoss in firePos)
        {
            GameObject obj = ObjectPoolingManager.Instance.getProj();
            if (obj == null) return;
            obj.transform.position = firePoss.position;
            obj.transform.rotation = firePoss.rotation;
            obj.transform.localScale = new Vector3((float)0.1824623, (float)1.5638, 1);
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoss.up * projSpeed, ForceMode2D.Impulse);
            obj.SetActive(true);
        }
    }
}