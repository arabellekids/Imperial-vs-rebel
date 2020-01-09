using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public float keepDist=100;
    public float thrust = 10;

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
        if (toPlayerDistance <= keepDist)
        {
            transform.LookAt(toPlayer);
            rb.AddForce((toPlayer/ toPlayerDistance) * thrust, ForceMode.Acceleration);
        }
    }
}
