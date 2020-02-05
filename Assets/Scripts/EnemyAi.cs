using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public Health health;
    [Range(1,100)]
    public int fearAmount = 1;
    public float fireRange = 5;

    public float aggroRange = 10000;
    public float thrust = 10;
    public float keepDist = 10;
    public float rotateSpeed = 10;
    public float maxAngularVelocity = 7;

    Transform playerToFollow;
    Rigidbody rb;
    public Transform[] players;
    public GameObject laser;
    float closestDistToPlyr = int.MaxValue;
    public float fireRate = 1;
    private float timer;

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
        chasePlayer();

    }
    void chasePlayer()
    {
        if (playerToFollow != null)
        {
            var toPlayer = playerToFollow.position - transform.position;
            var toPlayerDistance = toPlayer.magnitude;

            rb.maxAngularVelocity = maxAngularVelocity;
            if (health.health / health.maxHealth * 100 > fearAmount)
            {
                if(timer >= fireRate && toPlayerDistance <= fireRange)
                {
                    var bullet = Instantiate(laser, transform.position, transform.rotation, null);
                    bullet.GetComponent<BulletScript>().owner = gameObject;
                    timer = 0;
                }
                if (toPlayer.magnitude >= maxAngularVelocity)
                {
                    transform.forward = toPlayer;
                    transform.Rotate(Vector3.Cross(-transform.forward, toPlayer).normalized * rotateSpeed);
                }
                
                if (toPlayerDistance > keepDist)
                {
                    rb.AddForce((toPlayer) * thrust, ForceMode.Acceleration);
                }
            }
            else
            {
                transform.Rotate(-Vector3.Cross(-transform.forward, toPlayer).normalized * rotateSpeed);
                if (toPlayerDistance < aggroRange)
                {
                    rb.AddForce((-toPlayer) * thrust, ForceMode.Acceleration);
                }
            }
        }
        
    }
}
