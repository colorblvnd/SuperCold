using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMG : Weapon
{
    // Start is called before the first frame update
    void Start()
    {
        numProjectiles = 1;
        maxAmmoCount = 30;
        numAmmo = maxAmmoCount;
        nextShotDelay = 0.2f;
        loaded = true;
        accuracy = 96.0f;
        fullAuto = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
