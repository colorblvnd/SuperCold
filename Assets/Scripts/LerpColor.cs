using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpColor : MonoBehaviour
{
    private float current;
    private float target;
    private float speed;
    private Color origColor;
    private Color currColor;
    [SerializeField] private Color startLerpColor;

    // Start is called before the first frame update
    void Start()
    {
        origColor = GetComponent<MeshRenderer>().material.color;
        current = 0;
        target = 1;
        speed = 1.0f;
    }

    void Update()
    {
        current = Mathf.MoveTowards(current, target, speed * Time.unscaledDeltaTime);
        GetComponent<MeshRenderer>().material.color = Color.Lerp(startLerpColor, origColor, current);
    }

    public void BeginLerp(float p_target)
    {
        current = 0;
        speed = 1;
        speed /= p_target;
        GetComponent<MeshRenderer>().material.color = startLerpColor;
    }
}
