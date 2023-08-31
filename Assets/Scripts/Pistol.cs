using SerializableCallback;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Pistol : Weapon
{
    public bool yes;

    // Start is called before the first frame update
    void Start()
    {
        numProjectiles = 1;
        maxAmmoCount = 6;
        numAmmo = maxAmmoCount;
        nextShotDelay = 0.7f;
        loaded = true;
        accuracy = 98.0f;
        fullAuto = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (yes)
        {
            yes = false;
            Shoot();
        }
    }
}
