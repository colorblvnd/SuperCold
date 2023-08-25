using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    [SerializeField] private ParticleSystem ps;
    [SerializeField] private ParticleSystem.EmissionModule psEmission;
    [Range(0f, 1f)]
    public float gameSpeed;
    [Range(0, 100)]
    public int emission;

    // Start is called before the first frame update
    void Start()
    {
        psEmission = ps.emission;
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
        psEmission.rateOverTime = emission;
        ps.Simulate(Time.unscaledDeltaTime, true, false);
    }

    public void SetEmission(int rate)
    {
        psEmission.rateOverTime = rate;
    }
}
