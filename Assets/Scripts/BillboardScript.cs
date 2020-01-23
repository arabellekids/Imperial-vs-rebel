using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardScript : MonoBehaviour
{
    public Transform targetCam;
    public int enemyPlayerNum;

    // Update is called once per frame
    void Update()
    {
        targetCam = GameObject.Find("Player "+enemyPlayerNum+" cam").transform;
        if (targetCam != null)
        {
            transform.LookAt(targetCam.position);
        }
    }
}
