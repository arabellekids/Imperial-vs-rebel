using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameControl : MonoBehaviour
{
    public GameObject[] deathCams;
    public GameObject[] playerShips;
    public float maxPlyrSpwnDist = 200;
    public float respawnTime = 5f;
    public GameObject pausedScreen;
    public GameObject enemyPref;

    public float spawnRate = 5;
    private float timer;

    void Start()
    {
        timer = spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
        if (pausedScreen.activeSelf == false)
        {
            Time.timeScale = 1;
        }
        if (pausedScreen.activeSelf == true)
        {
            Time.timeScale = 0;
        }
        if (Input.GetButtonUp("Pause"))
        {
            pausedScreen.SetActive(!pausedScreen.activeSelf);
        }
        for (var i = 0; i < deathCams.Length; i++)
        {
            deathCams[i] = GameObject.Find("Player " + (i + 1) + " cam");
            var deathCamCode = deathCams[i].GetComponent<CamDefeated>();
            if (deathCamCode.timer >= respawnTime)
            {
                deathCamCode.shipDead = false;
                deathCamCode.timer = 0f;
                Instantiate(playerShips[deathCamCode.playerNum - 1], new Vector3(Random.Range(-maxPlyrSpwnDist / 2, maxPlyrSpwnDist / 2), Random.Range(-maxPlyrSpwnDist / 2, maxPlyrSpwnDist / 2), Random.Range(-maxPlyrSpwnDist / 2, maxPlyrSpwnDist / 2)), Random.rotation);
                var deathCamPos = GameObject.Find("Camera point " + deathCamCode.playerNum).transform;
                deathCams[i].transform.parent = deathCamPos;
                deathCams[i].transform.position = deathCamPos.position;
                deathCams[i].transform.rotation = deathCamPos.rotation;
            }
        }

    }
    public void ExitGame()
    {
        if (Application.isEditor)
        {
            EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }
    void SpawnEnemy()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Instantiate(enemyPref, new Vector3(
            Random.Range(-maxPlyrSpwnDist / 2, maxPlyrSpwnDist / 2),
            Random.Range(-maxPlyrSpwnDist / 2, maxPlyrSpwnDist / 2),
            Random.Range(-maxPlyrSpwnDist / 2, maxPlyrSpwnDist / 2)), Random.rotation);
            timer = spawnRate + Random.value*2;
        }

        
    }
}
