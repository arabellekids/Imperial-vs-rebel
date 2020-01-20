using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamDefeated : MonoBehaviour
{
    public int playerNum;
    [HideInInspector]
    public bool shipDead = false;
    public GameObject killer;
    [HideInInspector]
    public float timer;

    void LookAtKiller()
    {
        transform.LookAt(killer.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(shipDead == true)
        {
            LookAtKiller();
            timer += Time.deltaTime;
        }
    }
}
