using SerializableCallback;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Pistol : Weapon
{

    // Start is called before the first frame update
    void Start()
    {
        numProjectiles = 1;
        numAmmo = 6;
        nextShotDelay = 0.7f;
        loaded = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void OnActivated(ActivateEventArgs args)
    {
        base.OnActivated(args);
        Shoot();
    }
}
