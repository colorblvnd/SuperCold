using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Hands : XRDirectInteractor
{
    private Rigidbody rb;

    [SerializeField] private TextMeshProUGUI handInfo;

    Vector3 prevPos;
    Vector3 currPos;

    float distanceMoved;
    float velocity;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
        prevPos = transform.position;
        currPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        prevPos = currPos;
        currPos = transform.position;
        distanceMoved = Vector3.Distance(prevPos, currPos);
        velocity = distanceMoved < 0.0005f ? 0f : Mathf.Clamp(distanceMoved / Time.deltaTime, 0f, 1f);

        handInfo.text = distanceMoved.ToString() + "\n" + velocity.ToString();
        //Time.timeScale = velocity;
    }
}
