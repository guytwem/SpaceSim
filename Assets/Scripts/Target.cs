using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using System.Xml;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

/// <summary>
/// Class that controls asteroids.
/// </summary>
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

    
/// <summary>
/// When taking damage play asteroid particle effect
/// Lower health
/// if health hits 0 then asteroid death
/// </summary>
/// <param name="amount"></param>
    public void TakeDamage(float amount)
    {
        asteroidDeath.Play();
        health -= amount;
        if (health <= 0f)
        {
            
            Die();
            
        }
    }
/// <summary>
/// Destroy gameObject and randomise power drop.
/// </summary>
    public void Die()
    {
        
        Destroy(gameObject);
        DropPower();
        
    }
/// <summary>
/// Randomises wether a powerup will drop when an asteroid dies.
/// </summary>
    public void DropPower()
    {
        GameObject powerUpClone;
        randNum = Random.Range(0, 4);
        if( randNum == 1)
        {
            powerUpClone = (GameObject) Instantiate(powerUp, gameObject.transform.position, Quaternion.identity);

        }
    }
}
