using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

public abstract class Weapon : XRGrabInteractable
{

    [SerializeField] protected int numProjectiles;
    [SerializeField] protected int numAmmo;

    [SerializeField] protected float nextShotDelay;

    [SerializeField] public bool canShoot { get; protected set; }

    [SerializeField] protected GameObject bulletPrefab;

    [SerializeField] protected GameObject bulletSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void Shoot();
}
