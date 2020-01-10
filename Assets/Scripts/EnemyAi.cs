using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public float AggroRange =100;
    public float thrust = 10;
    public float keepDist = 10;

    Rigidbody rb;
    Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var toPlayer = player.position - transform.position;
        var toPlayerDistance = toPlayer.magnitude;
        if(toPlayerDistance> AggroRange)
        {
            rb.AddForce(transform.forward*(thrust/2),ForceMode.Acceleration);
        }
        if (toPlayerDistance <= AggroRange)
        {
            transform.LookAt(toPlayer);
            if(toPlayerDistance > keepDist)
            {
                rb.AddForce((toPlayer / toPlayerDistance) * thrust, ForceMode.Acceleration);
            }
            
        }
    }
}
