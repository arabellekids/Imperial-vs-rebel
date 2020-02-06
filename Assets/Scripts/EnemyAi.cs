using UnityEngine;
using System.Linq;
using Math = System.Math;
using System.Resources;
using System.Collections.Generic;


public class EnemyAi : MonoBehaviour
{
    public Health health;
    [Range(1, 100)]
    public int fearAmount = 1;
    public float fireRange = 5;

    public float aggroRange = 10000;
    public float thrust = 10;
    public float keepDist = 10;
    public float rotateSpeed = 10;
    public float maxAngularVelocity = 7;

    Transform playerToFollow;
    Rigidbody rb;
    public GameObject laser;
    float closestDistToPlyr = int.MaxValue;
    public float fireRate = 1;
    private float timer;
    public AudioClip fireSound;
    public Transform laserSpwnPoint;

    private Vector3 gameController;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameController = GameObject.FindGameObjectWithTag("GameController").transform.position;
        timer = fireRate + Random.value;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var distToCenter = transform.position.magnitude;
        if(distToCenter >= 1000)
        {
            Destroy(gameObject);
        }
        playerToFollow = (
                from player in Physics.OverlapSphere(transform.position, aggroRange)
                where player.CompareTag("Player")
                let distToPlayer = Vector3.Distance(transform.position, player.transform.position)
                orderby distToPlayer
                select player.transform
            ).FirstOrDefault();

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
                AttackMode(toPlayer, toPlayerDistance);
            }
            else
            {
                FearMode(toPlayer, toPlayerDistance);
            }
        }

    }

    private void FearMode(Vector3 toPlayer, float toPlayerDistance)
    {
        var desiredRotation = Quaternion.LookRotation(-toPlayer);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime / rotateSpeed);

        if (toPlayerDistance < aggroRange)
        {
            rb.AddForce((-toPlayer) * thrust);
        }
    }

    private void AttackMode(Vector3 toPlayer, float toPlayerDistance)
    {
        if (timer <= 0)
        {
            Fire();
        }

        var desiredRotation = Quaternion.LookRotation(toPlayer);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime / rotateSpeed);

        if (toPlayerDistance > keepDist)
        {
            rb.AddForce((toPlayer) * thrust);
        }
    }
    void Fire()
    {
        var bullet = Instantiate(laser, laserSpwnPoint.position, laserSpwnPoint.rotation, null);
        bullet.GetComponent<BulletScript>().owner = gameObject;

        timer = fireRate + Random.Range(-0.2f, 0.2f);
        AudioSource.PlayClipAtPoint(fireSound, gameController);
    }
}
