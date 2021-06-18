using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] resourceSource;

    public List<GameObject> spawnedResource;

    public List<GameObject> pool;

    public bool isSpawnedAsChild = false;

    public float minX = -100f;
    public float maxX = 100f;
    public float minY = -100f;
    public float maxY = 100f;
    public float minZ = -100f;
    public float maxZ = 100f;

    public GameObject Spawn()
    {

        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);
        float z = Random.Range(minZ, maxZ);

        GameObject spawnGameObject;
        if (pool.Count == 0)
        {
            spawnGameObject = (GameObject)Instantiate(resourceSource[Random.Range(0, resourceSource.Length)], new Vector3(x, y, z), Quaternion.identity);
        }
        else
        {
            pool[0].SetActive(true);
            spawnGameObject = pool[0];
            pool.RemoveAt(0);
        }

        if (isSpawnedAsChild)
        {
            spawnGameObject.transform.SetParent(transform);
        }
        spawnedResource.Add(spawnGameObject);
        return spawnGameObject;
    }

    /*public void Despawn(GameObject despawnObject)
    {
        if (despawnObject != null)
        {
            pool.Add(despawnObject);

            spawnedResource.Remove(despawnObject);

            despawnObject.SetActive(false);
        }
    }*/
}
