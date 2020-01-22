using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidLasers : MonoBehaviour
{
    public int playerNum;
    public GameObject laserOwner;

    public Transform[] guns;
    public GameObject laser;
    public float fireRate = 1;

    private float timer = 0;
    private int gunIndex = 0;

    void CheckForFire()
    {
        if(Input.GetAxis("Fire"+playerNum) != 0 && timer >= fireRate / guns.Length)
        {
            var bullet = Instantiate(laser, guns[gunIndex].position, guns[gunIndex].rotation, null);
            bullet.GetComponent<BulletScript>().owner = laserOwner;
            timer = 0;
            gunIndex++;
            if(gunIndex >= guns.Length)
            {
                gunIndex = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        CheckForFire();
    }
}
