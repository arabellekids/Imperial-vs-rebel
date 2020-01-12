using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject sparks;

    private float timer = 0;
    public float lifetime = 1;
    public float bulletSpeed = 2000;
    public float dmg = 2;
    Rigidbody rb;
    // Update is called once per frame
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.velocity = this.transform.forward*bulletSpeed*Time.deltaTime;
        rb.AddForce(this.transform.forward * bulletSpeed * Time.deltaTime, ForceMode.VelocityChange);
    }
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= lifetime)
        {
            Destroy(gameObject);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        bool destroySelf = true;
        Instantiate(sparks, transform.position, transform.rotation, transform);
        if (other.GetComponent<Health>() != null)
        {
            Health health = other.GetComponent<Health>();
            if (health.health > 0)
            {
                health.takedamage(dmg);
            }
            else if(health.health <= 0)
            {
                destroySelf = false;
            }

        }
        
        if(destroySelf == true)
        {
            Destroy(gameObject);
        }
        
    }
}
