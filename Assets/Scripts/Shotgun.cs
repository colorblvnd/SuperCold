using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{

    // Start is called before the first frame update
    void Start()
    {
        numProjectiles = 11;
        maxAmmoCount = 10;
        numAmmo = maxAmmoCount;
        nextShotDelay = 0.3f;
        loaded = true;
        accuracy = 95.0f;
        fullAuto = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
