using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private Rigidbody rb;
    private ShipMovement ship;
    public GameObject shipModel;
    public GameObject deathEffect;
    public float health = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        ship = GetComponent<ShipMovement>();
        rb = GetComponent<Rigidbody>();
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
            shipModel.SetActive(false);
            Instantiate(deathEffect, transform.position,transform.rotation,transform);

        }
        else
        {
            health -= dmg;
        }
    }
}
