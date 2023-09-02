using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    [SerializeField] private ParticleSystem ps;
    [SerializeField] private ParticleSystem.EmissionModule psEmission;

    [Range(0f, 100f)]
    public float emissionRate;
    public float gameSpeed;
    public float emissionLossPerSecond;
    [SerializeField] private float curveEval;
    [SerializeField] private Light torchLight;

    [SerializeField] private AnimationCurve curve;
    [SerializeField] private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        psEmission = ps.emission;
        emissionRate = 50;
        emissionLossPerSecond = 2;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateEmission()
    {
        gameSpeed = Time.timeScale;
        emissionRate -= emissionLossPerSecond * Time.unscaledDeltaTime;
        emissionRate += curve.Evaluate(gameSpeed) * Time.unscaledDeltaTime;
        emissionRate = Mathf.Clamp(emissionRate, 0f, 100f);
        psEmission.rateOverTime = emissionRate;
        torchLight.range = emissionRate / 2;
        if (emissionRate <= 0) { gameManager.GameOver(); }
        ps.Simulate(Time.unscaledDeltaTime, true, false);

    }
    public void TargetHit()
    {
        emissionRate += 10;
        emissionRate = Mathf.Clamp(emissionRate, 0f, 100f);

        psEmission.rateOverTime = emissionRate;
    }
}
