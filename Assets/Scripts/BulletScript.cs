using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int playerNum;

    public GameObject owner;
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
        Instantiate(sparks, transform.position, transform.rotation, null);

        if (other.GetComponent<Health>() != null)
        {
            Health health = other.GetComponent<Health>();
            health.attacker = owner;
            if (health.health > 0)
            {
                health.takedamage(dmg);
            }
        }
        
        Destroy(gameObject);
    }
}
