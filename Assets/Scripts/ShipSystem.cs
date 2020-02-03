using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSystem : MonoBehaviour
{
    public int playerNum;

    public AudioClip switchSound;
    public GameObject[] weaponTypes;
    private int typeIndex = 1;

    private Vector3 gameController;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").transform.position;
    }

    void SwitchWeapons(int index)
    {
        for(var i = 0;i < weaponTypes.Length; i++)
        {
            weaponTypes[i].SetActive(false);
        }
        weaponTypes[index].SetActive(true);
        AudioSource.PlayClipAtPoint(switchSound, gameController);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("CycleWeapons" + playerNum))
        {
            SwitchWeapons(typeIndex);
            typeIndex++;
            if (typeIndex >= weaponTypes.Length)
            {
                typeIndex = 0;
            }
        }
    }
}
