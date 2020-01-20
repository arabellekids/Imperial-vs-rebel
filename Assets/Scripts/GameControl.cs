using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public GameObject[] deathCams;
    public GameObject[] playerShips;
    public float maxPlyrSpwnDist = 200;
    public float respawnTime = 5f;

    // Update is called once per frame
    void Update()
    {
        for(var i = 0;i < deathCams.Length; i++)
        {
            deathCams[i] = GameObject.Find("Player " +(i+1)+ " cam");
            var deathCamCode = deathCams[i].GetComponent<CamDefeated>();
            if (deathCamCode.timer >= respawnTime)
            {
                deathCamCode.shipDead = false;
                deathCamCode.timer = 0f;
                Instantiate(playerShips[deathCamCode.playerNum-1], new Vector3(Random.Range(-maxPlyrSpwnDist / 2, maxPlyrSpwnDist / 2), Random.Range(-maxPlyrSpwnDist / 2, maxPlyrSpwnDist / 2), Random.Range(-maxPlyrSpwnDist / 2, maxPlyrSpwnDist / 2)), Random.rotation);
                var deathCamPos = GameObject.Find("Camera point " + deathCamCode.playerNum).transform;
                deathCams[i].transform.parent = deathCamPos;
                deathCams[i].transform.position = deathCamPos.position;
                deathCams[i].transform.rotation = deathCamPos.rotation;
            }
        }
    }
}
