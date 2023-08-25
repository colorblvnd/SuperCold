using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Pistol : Weapon
{

    public float time;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        numProjectiles = 1;
        numAmmo = 6;
        nextShotDelay = 0.3f;
        canShoot = true;

        time = 0;
        timer = 1;
    }

    // Update is called once per frame
    void Update()
    {
        /**
        time += Time.deltaTime;
        if (time > timer)
        {
            time = 0;
            Shoot();
        }**/
    }

    public override void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
    }

    protected override void OnActivated(ActivateEventArgs args)
    {
        base.OnActivated(args);
        Shoot();
    }
}
