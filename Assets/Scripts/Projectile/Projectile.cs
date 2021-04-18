using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projSpeed;
    public float bulletDeath;

    //private Rigidbody2D rb;
    private Shake shake;
    

    private void OnEnable()
    {
        
       //if(rb != null)
            //rb.velocity = Vector2.up * projSpeed;
        Invoke("Disable", bulletDeath);
    }

    void Start()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        //rb = GetComponent<Rigidbody2D>();
        //rb.velocity = Vector2.up * projSpeed;
    }

    private void Update()
    {
        transform.Translate(Vector2.up * projSpeed * Time.deltaTime);
            
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
        {
            shake.CamShake();
            Disable();
            
        }
        
    }
}
