using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Hands : XRDirectInteractor
{
    private Rigidbody rb;

    [SerializeField] private TextMeshProUGUI handInfo;
    [SerializeField] private TrackVelocity leftHandVelocity;
    [SerializeField] private TrackVelocity rightHandVelocity;
    [SerializeField] private TrackVelocity headVelocity;

    private float averageVelocity;

    public bool hasWeapon { get; private set; }
    public Weapon currWeapon { get; private set; }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
        hasWeapon = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        averageVelocity = (leftHandVelocity.velocity + rightHandVelocity.velocity + headVelocity.velocity) / 3;
        Time.timeScale = averageVelocity;
    }

    public void setCurrentWeapon(Weapon w)
    {
        hasWeapon = true;
        currWeapon = w;
    }

    public void dropWeapon()
    {
        hasWeapon = false;
        currWeapon = null;
    }
}
