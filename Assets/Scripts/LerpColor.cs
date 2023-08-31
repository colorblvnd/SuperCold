using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpColor : MonoBehaviour
{
    private float current;
    private float normal;
    private float speed;
    private Color orig;
    private Color currColor;
    private Color black;

    // Start is called before the first frame update
    void Start()
    {
        orig = GetComponent<MeshRenderer>().material.color;
        current = 0;
        normal = 1;
        speed = 1.0f;
        black = Color.black;
    }

    void Update()
    {
        current = Mathf.MoveTowards(current, normal, speed * Time.unscaledDeltaTime);
        GetComponent<MeshRenderer>().material.color = Color.Lerp(black, orig, current);
    }

    public void BeginLerp()
    {
        current = 0;
        GetComponent<MeshRenderer>().material.color = black;
    }
}
