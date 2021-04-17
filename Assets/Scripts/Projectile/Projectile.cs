using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //public float projSpeed;
    
    //private Rigidbody2D rb;

    private void OnEnable()
    {
       //if(rb != null)
            //rb.velocity = Vector2.up * projSpeed;
        Invoke("Disable", 5f);
    }

    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        //rb.velocity = Vector2.up * projSpeed;
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            Disable();
    }
}
