using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject playerGO;

    //Min Range to fire
    private float fireRange = 1.5f;
    public float speed;
    public float rotationSpeed;


    private void Awake()
    {
        playerGO = GameObject.FindGameObjectWithTag(Utils.PLAYER_TAG);
    }
    void Start()
    {
       
    }

    void Update()
    {
        if (playerGO == null)
            return;
        Vector2 dir = playerGO.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(angle,Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed *Time.deltaTime);

        if(!inRange()) transform.position = Vector2.MoveTowards(transform.position, playerGO.transform.position, speed * Time.deltaTime);
        

    }

    public bool inRange()
    {
        if (Vector2.Distance(transform.position, playerGO.transform.position) > fireRange) return false;
        
        else return true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
            Destroy(this.gameObject);
    }

}
