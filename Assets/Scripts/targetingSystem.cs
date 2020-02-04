using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetingSystem : MonoBehaviour
{
    public Transform fireCam;
    public Transform[] guns;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(fireCam.position, fireCam.forward, out hit))
        {
            for (var i = 0; i < guns.Length; i++)
            {
                guns[i].LookAt(hit.point);
            }
        }
        else
        {
            for (var i = 0; i < guns.Length; i++)
            {
                guns[i].rotation = Quaternion.LookRotation(fireCam.forward,fireCam.up);
            }
        }
    }
}
