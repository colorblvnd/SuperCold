using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    public bool yes;
    public bool full;

    // Start is called before the first frame update
    void Start()
    {
        numProjectiles = 11;
        maxAmmoCount = 10;
        numAmmo = maxAmmoCount;
        nextShotDelay = 0.3f;
        loaded = true;
        accuracy = 95.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (yes)
        {
            yes = false;
            Shoot();
        }

        if (full)
        {
            Shoot();
        }
    }
}
