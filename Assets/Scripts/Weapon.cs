using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

public abstract class Weapon : XRGrabInteractable
{

    [SerializeField] protected int numProjectiles;
    [SerializeField] protected int maxAmmoCount;
    [SerializeField] protected int numAmmo;

    [SerializeField] protected float nextShotDelay;
    [SerializeField] protected float accuracy;

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
        float randX = Random.Range(-100 + accuracy, 100 - accuracy);
        float randY = Random.Range(-100 + accuracy, 100 - accuracy);
        Instantiate(bulletPrefab, bulletSpawn.transform.position, Quaternion.Euler(new Vector3(bulletSpawn.transform.rotation.eulerAngles.x + randX, bulletSpawn.transform.rotation.eulerAngles.y + randY, bulletSpawn.transform.rotation.eulerAngles.z)));
    }

    private void AmmoConsumed()
    {
        numAmmo--;
    }

    public void AmmoPickedUp()
    {
        numAmmo++;
    }

    public bool HasAmmo()
    {
        return numAmmo > 0;
    }

    public void RefillAmmo()
    {
        numAmmo = maxAmmoCount;
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        GetComponent<Rigidbody>().useGravity = false;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        GetComponent<Rigidbody>().useGravity = true;
        //args.interactorObject.


        //base.OnSelectEntered(args);
        //m_BalloonInstance = Instantiate(balloonPrefab, attachPoint);
        //var controllerInteractor = args.interactorObject as XRBaseControllerInteractor;
        //m_Controller = controllerInteractor.xrController;

        //m_Controller.SendHapticImpulse(1, 0.5f);
    }

    protected override void OnActivated(ActivateEventArgs args)
    {
        base.OnActivated(args);
        Shoot();
    }
}
