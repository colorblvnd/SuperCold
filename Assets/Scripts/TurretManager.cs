using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    [SerializeField] List<Turret> turrets;

    public bool yes;

    private float timer;
    [SerializeField] float delay;
    private int currTurret;

    private enum TurretsState
    {
        Spiraling,
        Pulsing,
        Batches
    }

    // Start is called before the first frame update
    void Start()
    {
        delay = 0.9f;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (yes)
        {
            yes = false;
            ShootAll();
        }

        timer += Time.deltaTime;
        ShootAfterDelay();
    }

    void ShootAll()
    {
        foreach (Turret t in turrets)
        {
            t.Shoot();
        }
    }

    void ShootNextTurret()
    {
        turrets.ElementAt(currTurret).Shoot();
        currTurret++;
        currTurret = currTurret > 7 ? 0 : currTurret;
    }

    void ShootAfterDelay()
    {
        if (timer > delay)
        {
            timer -= delay;
            ShootNextTurret();
        }
    }
}
