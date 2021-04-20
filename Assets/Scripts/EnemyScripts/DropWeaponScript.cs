using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropWeaponScript : MonoBehaviour
{
    public GameObject [] turretsPrefab;
    [SerializeField]
    private float dropChance;
    [SerializeField]
    private float turretDC_1, turretDC_2, turretDC_3, turretDC_4, turretDC_5;

    public int dropIdx;
    public bool canDrop = false;

    void Start()
    {
        if(Random.Range(0,100) < dropChance)
        {
            canDrop = true;
            //Drop turret
            float dropTurret = Random.Range(0, 100);
            if(dropTurret < turretDC_1)
            {
                dropIdx = 0;
            }
            else if(dropTurret < turretDC_2)
            {
                dropIdx = 1;
            }
            else if(dropTurret < turretDC_3)
            {
                dropIdx = 2;
            }
            else if (dropTurret < turretDC_4)
            {
                dropIdx = 3;
            }
            else if(dropTurret < turretDC_5)
            {
                dropIdx = 4;

            }
        }        
    }

    
    public GameObject dropWeapon()
    {
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360)));
        GameObject weapon = Instantiate(turretsPrefab[dropIdx], transform.position, rotation);
        weapon.transform.localScale = new Vector2(0.3f, 0.3f);
        return weapon;
    }
}
