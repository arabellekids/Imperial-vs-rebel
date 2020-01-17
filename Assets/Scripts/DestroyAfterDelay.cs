using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDelay : MonoBehaviour
{
    public float delayTime;
    private float timer = 0;
    
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= delayTime)
        {
            timer = 0;
            Destroy(gameObject);
        }
    }
}
