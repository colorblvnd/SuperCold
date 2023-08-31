using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    [SerializeField] private ParticleSystem ps;
    [SerializeField] private ParticleSystem.EmissionModule psEmission;
    [Range(0f, 1f)]
    public float gameSpeed;

    [Range(0f, 100f)]
    public float emissionRate;

    [SerializeField] private AnimationCurve curve;
    [SerializeField] private float curveEval;

    // Start is called before the first frame update
    void Start()
    {
        psEmission = ps.emission;
        emissionRate = 50;
    }

    // Update is called once per frame
    void Update()
    {
        //Time.timeScale = gameSpeed;
        emissionRate += curve.Evaluate(gameSpeed) * Time.unscaledDeltaTime;
        emissionRate = Mathf.Clamp(emissionRate, 0f, 100f);

        psEmission.rateOverTime = emissionRate;


        ps.Simulate(Time.unscaledDeltaTime, true, false);
    }

    public void SetEmission(int rate)
    {
        psEmission.rateOverTime = rate;
    }
}
