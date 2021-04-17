using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBullet : MonoBehaviour
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
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

    }

    void Shoot()
    {
        for(int i = 0; i <= 2; i++)
        {
            GameObject obj = ObjectPoolingManager.Instance.getProj();
            if (obj == null) return;
            obj.transform.position = firePos.position;
            obj.transform.rotation = firePos.rotation;
            obj.transform.localScale = new Vector3((float)0.1824623, (float)1.5638, 1);
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            
            switch(i)
            {
                case 0:            
                    rb.AddForce(firePos.up * projSpeed + new Vector3(0f, 90f, 0f), ForceMode2D.Impulse);
                    obj.SetActive(true);
                    break;                
                case 1:            
                    rb.AddForce(firePos.up * projSpeed + new Vector3(0f, 0f, 0f), ForceMode2D.Impulse);
                    obj.SetActive(true);
                    break;                
                case 2:            
                    rb.AddForce(firePos.up * projSpeed + new Vector3(0f, -90f, 0f), ForceMode2D.Impulse);
                    obj.SetActive(true);
                    break;
                

        }

        }
    }
}
