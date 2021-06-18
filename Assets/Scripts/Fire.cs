using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;

    public GameObject laserPrefab;
    public GameObject firePoint;

    private GameObject spawnedLaser;

    public LayerMask asteroids;

    public Camera fpsCam;

    private void Start()
    {
        spawnedLaser = Instantiate(laserPrefab, firePoint.transform) as GameObject;
        DisableLaser();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            EnableLaser();
        }
        if (Input.GetButton("Fire1"))
        {
            UpdateLaser();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            DisableLaser();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, asteroids))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
    void EnableLaser()
    {
        spawnedLaser.SetActive(true);
    }
    void DisableLaser()
    {
        spawnedLaser.SetActive(false);
    }
    void UpdateLaser()
    {
        if (firePoint != null)
        {
            spawnedLaser.transform.position = firePoint.transform.position;
        }
    }

}
