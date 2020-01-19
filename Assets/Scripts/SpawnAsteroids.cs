using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour
{
    public GameObject[] asteroidPrefs;
    public int numOfAsteroids = 5;
    public float maxSpawnDist = 100;

    // Start is called before the first frame update
    void Start()
    {
        for(var i = 0; i < numOfAsteroids; i++)
        {
            CreateAsteroid();
        }
    }
    GameObject CreateAsteroid()
    {
        var astIdx = Random.Range(0, asteroidPrefs.Length);
        var ast = Instantiate(asteroidPrefs[astIdx],new Vector3(Random.Range(-maxSpawnDist/2,maxSpawnDist/2), Random.Range(-maxSpawnDist / 2, maxSpawnDist / 2), Random.Range(-maxSpawnDist / 2, maxSpawnDist / 2)),Quaternion.identity);
        ast.GetComponent<Rigidbody>().AddRelativeTorque(Random.rotation.eulerAngles);
        return ast;
    }
}
