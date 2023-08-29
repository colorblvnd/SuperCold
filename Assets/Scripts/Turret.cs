using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Turret : MonoBehaviour
{
    [SerializeField] private GameObject YRotator;
    [SerializeField] private GameObject XRotator;
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject bulletSpawn;
    [SerializeField] private GameObject bulletPrefab;

    private float maxYDegrees;
    private float initialYRotation;

    private Vector3 YTransform;
    private Quaternion newRotation;

    // Start is called before the first frame update
    void Start()
    {
        maxYDegrees = 30;
        initialYRotation = YRotator.transform.localEulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        YRotator.transform.LookAt(new Vector3(target.transform.position.x, YRotator.transform.position.y, target.transform.position.z));
        XRotator.transform.LookAt(new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z));
        YTransform = YRotator.transform.localEulerAngles;

        if (Mathf.Abs(YTransform.y - initialYRotation) > maxYDegrees)
        {
            YTransform.y = Mathf.Clamp(YTransform.y, initialYRotation - maxYDegrees, initialYRotation + maxYDegrees);
            YRotator.transform.localRotation = Quaternion.Euler(YTransform);
        }
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawn.transform.position, Quaternion.Euler(bulletSpawn.transform.rotation.eulerAngles));
    }
}
