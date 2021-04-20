using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretChange : MonoBehaviour
{

    public GameObject[] turrets;
    public GameObject dropWeapon;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("TurretDrop"))
        {
            GameObject obj = Instantiate(turrets[dropWeapon.GetComponent<DropWeaponScript>().dropIdx], transform.GetChild(1).position, Quaternion.identity);
            obj.transform.SetParent(transform.GetChild(1));
        }
    }
}
