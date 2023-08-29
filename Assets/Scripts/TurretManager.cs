using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    [SerializeField] List<Turret> turrets;

    public bool yes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (yes)
        {
            yes = false;
            ShootAll();
        }
    }

    void ShootAll()
    {
        foreach (Turret t in turrets)
        {
            t.Shoot();
        }
    }
}
