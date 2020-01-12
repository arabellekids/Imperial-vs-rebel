using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Rigidbody rb;
    public ShipMovement ship;
    public GameObject shipModel;
    public GameObject deathEffect;
    public float health = 10;
    private bool hasDied = false;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void takedamage (float dmg)
    {
        if (health - dmg <= 0)
        {
            rb.drag = 100;
            rb.angularDrag = 100;
            ship.thrust = 0;
            ship.torque = 0;
            health = 0;
            if(shipModel.activeSelf == true)
            {
                Instantiate(deathEffect, transform.position, transform.rotation, null);
            }
            shipModel.SetActive(false);
        }
        else
        {
            health -= dmg;
        }
    }
}
