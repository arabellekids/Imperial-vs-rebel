﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldScript : MonoBehaviour
{
    public Slider shieldBar;

    public GameObject player;

    public int layerNum;
    public float maxShields = 10;
    public float rechargeRate = 3;
    public float rechargeValue = 2;

    private float shields = 1;
    private float sliderValue;
    private float timer = 0;
    
    public void TakeDamage(float dmg)
    {
        if(shields - dmg <= 0)
        {
            player.layer = layerNum;
            gameObject.layer = 15;
            shields = 0;
            timer = 0;
        }
        else
        {
            shields -= dmg;
            timer = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        shields = maxShields;
    }

    // Update is called once per frame
    void Update()
    {
        if(shields < maxShields)
        {
            timer += Time.deltaTime;
        }
        if(timer >= rechargeRate)
        {
            timer = 0;
            shields += rechargeValue;
            gameObject.layer = layerNum;
            player.layer = 15;
            if (shields > maxShields)
            {
                shields = maxShields;
            }
        }
        sliderValue = shields / maxShields;
        shieldBar.value = sliderValue;
    }
}
