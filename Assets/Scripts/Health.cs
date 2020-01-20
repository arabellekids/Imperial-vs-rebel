using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [HideInInspector]
    public GameObject attacker = null;

    public AudioClip HitSound;
    public AudioClip DieSound;
    public Slider healthBar;
    public GameObject deathCam;
    public GameObject deathEffect;
    public float health = 10;
    public float maxHealth = 10;
    private bool hasDied = false;
    private Vector3 gameController;
    // Start is called before the first frame update
    private void Start()
    {
        health = maxHealth;
        gameController = GameObject.FindGameObjectWithTag("GameController").transform.position;
    }
    public void takedamage (float dmg)
    {
        if (health - dmg <= 0)
        {
            AudioSource.PlayClipAtPoint(DieSound, gameController);
            deathCam.transform.parent = null;
            deathCam.GetComponent<CamDefeated>().killer = attacker;
            deathCam.GetComponent<CamDefeated>().shipDead = true;
            health = 0;
            Instantiate(deathEffect, transform.position, transform.rotation, null);
            Destroy(gameObject);

        }
        else
        {
            health -= dmg;
            var barDmg = dmg / maxHealth;
            healthBar.value -= barDmg;
            AudioSource.PlayClipAtPoint(HitSound, gameController);
            
        }
    }
}
