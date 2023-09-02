using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackVelocity : MonoBehaviour
{

    Vector3 prevPos;
    Vector3 currPos;

    [SerializeField] float distanceMoved;
    public float velocity { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        prevPos = transform.position;
        currPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        prevPos = currPos;
        currPos = transform.position;
        distanceMoved = Vector3.Distance(prevPos, currPos);
        velocity = distanceMoved < 0.0005f ? 0f : distanceMoved / Time.deltaTime;
    }
}
