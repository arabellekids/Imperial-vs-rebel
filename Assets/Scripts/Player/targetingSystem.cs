using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        var hits = Physics.RaycastAll(fireCam.position, fireCam.forward);
        var hit = hits.FirstOrDefault(x => !GetAncestors(x.collider).Contains(gameObject));
        if (hit.collider!= null)
        {
            for (var i = 0; i < guns.Length; i++)
            {
                guns[i].LookAt(hit.point);
            }
            if(hit.collider.gameObject.GetComponent<Health>() != null || hit.collider.gameObject.GetComponent<ShieldScript>() != null)
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

    private IEnumerable<GameObject> GetAncestors(Component component)
    {
        var o = component.gameObject.transform;
        while (o != null)
        {
            yield return o.gameObject;
            o = o.parent;
        }
    }
}
