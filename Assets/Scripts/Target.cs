using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public ParticleSystem asteroidDeath;
    
    private int randNum;
    public GameObject powerUp;

    public void Update()
    {
        try
        {
            health--;
        }
        catch (Exception e)
        {
            Console.WriteLine(health);
            throw;
        }
    }

    

    public void TakeDamage(float amount)
    {
        asteroidDeath.Play();
        health -= amount;
        if (health <= 0f)
        {
            
            Die();
            
        }
    }

    void Die()
    {
        
        Destroy(gameObject);
        DropPower();
        
    }

    void DropPower()
    {
        GameObject powerUpClone;
        randNum = Random.Range(0, 4);
        if( randNum == 1)
        {
            powerUpClone = (GameObject) Instantiate(powerUp, gameObject.transform.position, Quaternion.identity);

        }
    }
}
