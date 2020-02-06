using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class targetingSystem : MonoBehaviour
{
    public Transform fireCam;
    public Transform[] guns;
    public Image sniperCursor;
    public Sprite nothingSelected;
    public Sprite targetSelected;

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
            if(hit.collider.gameObject.GetComponent<Health>() != null)
            {
                sniperCursor.sprite = targetSelected;
            }
            else
            {
                sniperCursor.sprite = nothingSelected;
            }
        }
        else
        {
            for (var i = 0; i < guns.Length; i++)
            {
                guns[i].rotation = Quaternion.LookRotation(fireCam.forward,fireCam.up);
            }
            sniperCursor.sprite = nothingSelected;
        }
    }
}
