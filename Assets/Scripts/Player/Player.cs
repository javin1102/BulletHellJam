using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player")]
    public float speed;

    [Header("Map")]
    public float horizontalBorder;
    public float verticalBorder;

    [Header("Bar")]
    public float currTime;
    public float maxTime = 10;

    [Header("Others")]
    public GameObject objPrefab;
    public Camera cam;
    public StyleTime styleTime;

    Rigidbody2D rb;

    Vector2 mousePos;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currTime = 0;
        styleTime.SetMaxTime(maxTime);
    }

    void Update()
    {
        //Movement(1)
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed, 0.0f);
        //transform.position = transform.position + movement * Time.deltaTime;

        //Movement(2)
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector3(xMov, zMov, 0f) * speed;

        //Border
        if (transform.position.x < -horizontalBorder) transform.position = new Vector3(-horizontalBorder, transform.position.y, transform.position.z);
        if (transform.position.x > horizontalBorder) transform.position = new Vector3(horizontalBorder, transform.position.y, transform.position.z);
        if (transform.position.y < -verticalBorder) transform.position = new Vector3(transform.position.x, -verticalBorder, transform.position.z);
        if (transform.position.y > verticalBorder) transform.position = new Vector3(transform.position.x, verticalBorder, transform.position.z);

        //Shooting
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetMouseButton(0))
        {
            currTime += Time.deltaTime;
            styleTime.SetTime(currTime);
        }

        //Bar
        if (styleTime.slider.value >= 10f)
        {
            styleTime.SetTime(0);
            currTime = 0;
        }
            
    }

    private void FixedUpdate()
    {
        //Rotate Player
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Bullet"))
            Debug.Log("You're dead");
    }
}
