using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] PoolManager asteroidPool;
    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < 50; x++)
        {
            asteroidPool.Spawn();
        }
        StartCoroutine(despawnAsteroids());
    }

    IEnumerator despawnAsteroids()
    {
        while (asteroidPool.spawnedResource.Count > 0)
        {
            yield return new WaitForSeconds(5f);

            //asteroidPool.Despawn(asteroidPool.spawnedResource[0]);
        }
    }
}
