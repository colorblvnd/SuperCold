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

    Vector3 prevPos;
    Vector3 currPos;

    float distanceMoved;
    public float leftVelocity;

    // Start is called before the first frame update
    void Start()
    {
        psEmission = ps.emission;
        emissionRate = 50;
        prevPos = transform.position;
        currPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //gameSpeed = Time.timeScale; 
        Time.timeScale = gameSpeed;
        emissionRate += curve.Evaluate(gameSpeed) * Time.unscaledDeltaTime;
        emissionRate = Mathf.Clamp(emissionRate, 0f, 100f);

        psEmission.rateOverTime = emissionRate;


        ps.Simulate(Time.unscaledDeltaTime, true, false);

        prevPos = currPos;
        currPos = transform.position;
        distanceMoved = Vector3.Distance(prevPos, currPos);
        leftVelocity = distanceMoved < 0.0005f ? 0f : Mathf.Clamp(distanceMoved / Time.deltaTime, 0f, 1f);
    }

    public void SetEmission(int rate)
    {
        psEmission.rateOverTime = rate;
    }
}
