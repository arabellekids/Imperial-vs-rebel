﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void takedamage (float dmg)
    {
        if (health - dmg <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            health -= dmg;
        }
    }
}
