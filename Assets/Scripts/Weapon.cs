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
    
    [SerializeField] public bool loaded { get; protected set; }

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

    public virtual void Shoot()
    {
        if (CanShoot())
        {
            AmmoConsumed();
            loaded = false;
            Invoke(nameof(LoadBullet), nextShotDelay);
            for (int i = 0; i < numProjectiles; i++)
            {
                SpawnBullet();
            }
        }
    }

    private void LoadBullet()
    {
        loaded = true;
    }

    private bool CanShoot()
    {
        if (numAmmo > 0 && loaded)
        {
            return true;
        }
        return false;
    }

    private void SpawnBullet()
    {
        Instantiate(bulletPrefab, bulletSpawn.transform.position, Quaternion.Euler(bulletSpawn.transform.rotation.eulerAngles));
    }

    private void AmmoConsumed()
    {
        numAmmo--;
    }

    protected void AmmoPickedUp()
    {
        numAmmo++;
    }

    public bool HasAmmo()
    {
        return numAmmo > 0;
    }
}
