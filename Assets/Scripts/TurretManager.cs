using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    [SerializeField] List<Turret> turrets;

    private float shotTimer;
    private float stateTimer;
    private float stateSwitchDelay;

    [SerializeField] private float spiralingDelay;
    [SerializeField] private float pulsingDelay;
    [SerializeField] private float batchesDelay;

    private int currTurret;
    private int numStates;

    private bool turretsActive;

    private TurretState state;

    [SerializeField] ScreensManager screenManager;

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
        shotTimer = 0;
        stateTimer = 0;
        stateSwitchDelay = 10f;
        numStates = System.Enum.GetValues(typeof(TurretState)).Length - 1;
        turretsActive = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateTurrets()
    {
        stateTimer += Time.deltaTime;
        shotTimer += Time.deltaTime;
        screenManager.UpdateAllScreenTexts("Time until next phase: " + (int)(stateSwitchDelay - stateTimer + 1) + "\n" + "Current turret state: " + state);

        if (stateTimer >= stateSwitchDelay)
        {
            stateTimer -= stateSwitchDelay;
            CycleState();
        }

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

    public void CycleState()
    {
        shotTimer = 0;
        state += 1;
        if ((int)state > numStates) { state -= 3; }
        Debug.Log(state);
    }

    public void SetIdle()
    {
        state = TurretState.Idle;
        SetAllTurretsActive(false);
    }

    private void ShootAll()
    {
        foreach (Turret t in turrets) { t.Shoot(); }
    }

    private void ShootNextTurret()
    {
        turrets.ElementAt(currTurret).Shoot();
        currTurret++;
        currTurret = currTurret > 7 ? 0 : currTurret;
    }

    private void SpiralShooting()
    {
        if (shotTimer >= spiralingDelay)
        {
            shotTimer -= spiralingDelay;
            ShootNextTurret();
        }
    }

    private void PulseShooting()
    {
        if (shotTimer >= pulsingDelay)
        {
            shotTimer -= pulsingDelay;
            ShootAll();
        }
    }

    private void BatchShooting()
    {
        currTurret = currTurret % 2 == 0 ? currTurret : currTurret - 1;
        if (shotTimer >= batchesDelay)
        {
            shotTimer -= batchesDelay;
            for (int i = 0; i < 2; i++) { ShootNextTurret(); }
        }
    }

    public void SetAllTurretsActive(bool activated)
    {
        foreach (Turret t in turrets) { t.SetTurretActive(activated); }
        turretsActive = activated;
    }

    public void IncreaseDifficulty()
    {
        spiralingDelay -= 0.05f;
        pulsingDelay -= 0.05f;
        batchesDelay -= 0.05f;
    }
}
