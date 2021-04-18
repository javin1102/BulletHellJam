using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : MonoBehaviour
{
    [Header("Player")]
    public float speed;
    public int rotationSpeedTank;
    public int rotationSpeedTurret;
    public int playerMaxLife;
    public float maxInvicibilityFrame;
    public Animator animator;
    public Transform respawnPos;
    
    [Header("Turret")]
    public Animator animatorTurret_1;
    public Animator animatorTurret_2;
    public Animator animatorTurret_3;
    public Animator animatorTurret_4;
    public Animator animatorTurret_5;

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
    public SpriteRenderer spriteChassie;
    public SpriteRenderer spriteT1;
    public SpriteRenderer spriteT2;
    public SpriteRenderer spriteT3;
    public SpriteRenderer spriteT4;
    public SpriteRenderer spriteT5;

    Rigidbody2D rb;

    Transform tankBody;
    Transform tankTurret;

    private bool shoot;

    [SerializeField]
    private int playerLife;
    [SerializeField]
    private float invicibilityFrame;
    [SerializeField]
    private bool invis = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tankBody = transform.Find("Chassie");
        tankTurret = transform.Find("TurretStyle");

        currTime = 0;
        styleTime.SetMaxTime(maxTime);

        playerLife = playerMaxLife;
    }

    void Update()
    {
        //Movement(1)
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed, 0.0f);
        //transform.position = transform.position + movement * Time.deltaTime;

        //Movement(2)
        //float xMov = Input.GetAxisRaw("Horizontal");
        //float zMov = Input.GetAxisRaw("Vertical");

        //rb.velocity = new Vector3(xMov, zMov, 0f) * speed;



        //Border
        if (transform.position.x < -horizontalBorder) transform.position = new Vector3(-horizontalBorder, transform.position.y, transform.position.z);
        if (transform.position.x > horizontalBorder) transform.position = new Vector3(horizontalBorder, transform.position.y, transform.position.z);
        if (transform.position.y < -verticalBorder) transform.position = new Vector3(transform.position.x, -verticalBorder, transform.position.z);
        if (transform.position.y > verticalBorder) transform.position = new Vector3(transform.position.x, verticalBorder, transform.position.z);

        //Shooting
        if (Input.GetMouseButton(0))
        {
            shoot = true;
            animatorTurret_1.SetBool("isShooting", shoot);
            animatorTurret_2.SetBool("isShooting", shoot);
            animatorTurret_3.SetBool("isShooting", shoot);
            animatorTurret_4.SetBool("isShooting", shoot);
            animatorTurret_5.SetBool("isShooting", shoot);
            currTime += Time.deltaTime;
            styleTime.SetTime(currTime);
        }
        else
        {
            shoot = false;
            animatorTurret_1.SetBool("isShooting", shoot);
            animatorTurret_2.SetBool("isShooting", shoot);
            animatorTurret_3.SetBool("isShooting", shoot);
            animatorTurret_4.SetBool("isShooting", shoot);
            animatorTurret_5.SetBool("isShooting", shoot);
        }
            

        //Bar
        if (styleTime.slider.value >= 10f)
        {
            styleTime.SetTime(0);
            currTime = 0;
        }

        //Invincibility Fram
        if(invis == true)
        {
            invicibilityFrame += Time.deltaTime;
            if(invicibilityFrame >= maxInvicibilityFrame)
            {
                invis = false;
                spriteChassie.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
                spriteT1.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
                spriteT2.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
                spriteT3.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
                spriteT4.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
                spriteT5.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
                invicibilityFrame = 0;
            }
        }

    }

    private void FixedUpdate()
    {
        //MovePlayer();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Bullet"))
        {
            playerLife--;
            Invoke("Respawn", 1f);

            this.gameObject.SetActive(false);
            if(playerLife <= 0)
                Debug.Log("You're dead");
        }
            
    }

    public void MovePlayer(float inputValue)
    {
        rb.velocity = tankBody.up * inputValue * speed;
        animator.SetFloat("Magnitude", rb.velocity.magnitude);
    }

    public void RotateTankBody(float inputValue)
    {
        float rotation = -inputValue * rotationSpeedTank;
        tankBody.Rotate(Vector3.forward * rotation);
    }

    public void RotateTankTurret(Vector3 endpoint)
    {
        Quaternion desiredRotation = Quaternion.LookRotation(Vector3.forward, endpoint - tankTurret.position);
        //desiredRotation = Quaternion.Euler(0, 0, desiredRotation.eulerAngles.z + 90);
        tankTurret.rotation = Quaternion.RotateTowards(tankTurret.rotation, desiredRotation, rotationSpeedTurret * Time.deltaTime);
    }

    void Respawn()
    {
        this.gameObject.SetActive(true);
        this.gameObject.transform.position = respawnPos.position;
        spriteChassie.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);
        spriteT1.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);
        spriteT2.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);
        spriteT3.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);
        spriteT4.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);
        spriteT5.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);
        invis = true;
    }
}
