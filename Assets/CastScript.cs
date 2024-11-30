using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastScript : MonoBehaviour
{
    //Trnasform component that will the starting point for the spell
    public Transform Firepoint;
    //Prefab of the spell
    public GameObject spell;

    // Update is called once per frame
    void Update()
    {
        //if the player clicks mouse down fire the spell
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(spell, Firepoint.position, Firepoint.rotation);
        }
    }
}
