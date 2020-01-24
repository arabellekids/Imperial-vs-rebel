using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleLasers : MonoBehaviour
{
    public int playerNum;
    public GameObject laserOwner;

    public Transform[] guns;
    public GameObject laser;
    public float fireRate = 1;
    public AudioClip fireSound;

    private Vector3 gameController;

    private float timer = 0;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").transform.position;
    }
    void CheckForFire()
    {
        if (Input.GetAxis("Fire" + playerNum) != 0 && timer >= fireRate)
        {
            for(var i = 0; i < guns.Length; i++)
            {
                var bullet = Instantiate(laser, guns[i].position, guns[i].rotation, null);
                bullet.GetComponent<BulletScript>().owner = laserOwner;
                
            }
            timer = 0;
            AudioSource.PlayClipAtPoint(fireSound, gameController);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        CheckForFire();
    }
}
