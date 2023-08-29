using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private GameObject YRotator;
    [SerializeField] private GameObject XRotator;
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject bulletSpawn;


    [SerializeField] private GameObject bullet;

    private float maxYDegrees;
    private float initialYRotation;

    private Vector3 YTransform;
    private Quaternion newRotation;

    // Start is called before the first frame update
    void Start()
    {
        maxYDegrees = 30;
        initialYRotation = 180;
    }

    // Update is called once per frame
    void Update()
    {
        YTransform = YRotator.transform.localEulerAngles;
        YRotator.transform.LookAt(new Vector3(target.transform.position.x, YRotator.transform.position.y, target.transform.position.z));
        XRotator.transform.LookAt(new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z));

        if (Mathf.Abs(YTransform.y - initialYRotation) > maxYDegrees)
        {
            newRotation = Quaternion.Euler(YTransform.x, Mathf.Clamp(YTransform.y, 150f, 210f), YTransform.z);
            YRotator.transform.rotation = newRotation;
        }
    }
}
