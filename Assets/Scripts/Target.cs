using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public ParticleSystem asteroidDeath;
    private UI uI;
    private GameObject canvas;
    private int randNum;
    public GameObject powerUp;

    private void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        uI = canvas.GetComponent<UI>();
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
        uI.asteroidsDestroyed++;
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
