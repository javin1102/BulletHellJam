using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoBulletsSide : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private float fireRate = 5f;
    [SerializeField] private float speed = 10f;
    [SerializeField] private int ID = 1;
    public bool canShoot = true;

    [Header("Shooting Mechanic")]
    public Transform[] firePos = new Transform[2];

    private float nextTimeToFire = 0f;
    public GameObject styleSwitch;

    void Start()
    {
        
    }

    void Update()
    {
        //Shoot
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && canShoot)
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
            obj.GetComponent<Projectile>().projSpeed = speed;
            obj.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            styleSwitch.GetComponent<StyleSwitch>().Switch(ID);
        }
    }
}
