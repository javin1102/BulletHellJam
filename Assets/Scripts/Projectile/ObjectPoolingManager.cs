using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour
{
    private static ObjectPoolingManager instance;

    public static ObjectPoolingManager Instance { get { return instance; } }

    public GameObject projPrefab;
    public int projAmount = 20;

    private List<GameObject> projectiles;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

        projectiles = new List<GameObject>(projAmount);
        for(int i = 0; i < projAmount; i++)
        {
            GameObject prefabInstance = Instantiate(projPrefab);
            prefabInstance.transform.SetParent(transform);
            prefabInstance.SetActive(false);

            projectiles.Add(prefabInstance);
        }
    }

    public GameObject getProj()
    {
        foreach (GameObject projectile in projectiles)
        {
            if(!projectile.activeInHierarchy)
            {
                projectile.SetActive(true);
                return projectile;
            }
        }
        GameObject prefabInstance = Instantiate(projPrefab);
        prefabInstance.transform.SetParent(transform);
        projectiles.Add(prefabInstance);

        return prefabInstance;
    }
}
