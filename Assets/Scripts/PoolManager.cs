using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject projectile;
    public List<GameObject> projectilePool;
    public int projectileAmount;


    private void Awake()
    {
        StartPool();
    }
    private void StartPool()
    {
        projectilePool = new List<GameObject>();
        for(int i = 0; i < projectileAmount; i++)
        {
            var obj = Instantiate(projectile, transform);
            obj.SetActive(false);
            projectilePool.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0; i < projectileAmount; i++)
        {
            if (!projectilePool[i].activeInHierarchy)
            {
                return projectilePool[i];
            }
        }
        return null;
    }

}
