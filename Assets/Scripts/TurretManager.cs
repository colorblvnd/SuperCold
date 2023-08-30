using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    [SerializeField] List<Turret> turrets;

    public bool yes;

    private float timer;
    private int currTurret;
    [SerializeField] private TurretState state;
    private int numStates;

    [SerializeField] float spiralingDelay;
    [SerializeField] float pulsingDelay;
    [SerializeField] float batchesDelay;

    private enum TurretState
    {
        Idle,
        Spiraling,
        Pulsing,
        Batches
    }

    // Start is called before the first frame update
    void Start()
    {
        spiralingDelay = 0.9f;
        pulsingDelay = 1.5f;
        batchesDelay = 1.3f;
        timer = 0;
        numStates = System.Enum.GetValues(typeof(TurretState)).Length - 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (yes)
        {
            yes = false;
            CycleState();
            currTurret = 0;
        }

        timer += Time.deltaTime;

        switch (state)
        {
            case TurretState.Idle:
                break;
            case TurretState.Spiraling:
                SpiralShooting();
                break;
            case TurretState.Pulsing:
                PulseShooting();
                break;
            case TurretState.Batches:
                BatchShooting();
                break;
        }
    }

    void CycleState()
    {
        timer = 0;
        state += 1;
        if ((int)state > numStates)
        {
            state -= 3;
        }
        Debug.Log(state);
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

    void SpiralShooting()
    {
        if (timer > spiralingDelay)
        {
            timer -= spiralingDelay;
            ShootNextTurret();
        }
    }

    void PulseShooting()
    {
        if (timer > pulsingDelay)
        {
            timer -= pulsingDelay;
            ShootAll();
        }
    }

    void BatchShooting()
    {
        if (timer > batchesDelay)
        {
            timer -= batchesDelay;
            for (int i = 0; i < 2; i++)
            {
                ShootNextTurret();
            }
        }
    }
}
