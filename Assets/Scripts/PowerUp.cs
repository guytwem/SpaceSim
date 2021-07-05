using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private ShipController controller;
    private GameObject ship;

    private void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Player");
        controller = ship.GetComponent<ShipController>();
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Power Up");
            controller.forwardSpeed += 10;
            controller.hoverSpeed += 10;
            controller.strafeSpeed += 10;
            Destroy(gameObject);
        }
       
         
        
    }

   

   
}
