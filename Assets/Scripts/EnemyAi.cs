using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public float aggroRange = 10000;
    public float thrust = 10;
    public float keepDist = 10;
    public float rotateSpeed = 10;

    Transform playerToFollow;
    Rigidbody rb;
    public Transform[] players;
    float closestDistToPlyr = int.MaxValue;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (var i = 0; i < players.Length; i++)
        {
            float distToPlayer = Vector3.Distance(transform.position, players[i].transform.position);
            if (distToPlayer < closestDistToPlyr)
            {
                closestDistToPlyr = distToPlayer;
                playerToFollow = players[i];
            }
        }
        if(playerToFollow != null)
        {
            var toPlayer = Vector3.Normalize(playerToFollow.position - transform.position);
            var toPlayerDistance = toPlayer.magnitude;
            
            rb.AddRelativeTorque(Vector3.Cross(transform.forward, toPlayer).normalized*rotateSpeed);
            
            if (toPlayerDistance > keepDist)
            {
                rb.AddForce((transform.forward) * thrust, ForceMode.Acceleration);
            }
        }
    }
}
