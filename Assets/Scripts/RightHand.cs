using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RightHand : XRDirectInteractor
{

    public bool hasWeapon { get; private set; }
    public Weapon currWeapon { get; private set; }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        hasWeapon = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetCurrentWeapon(Weapon w)
    {
        hasWeapon = true;
        currWeapon = w;
    }

    public void DropWeapon()
    {
        hasWeapon = false;
        currWeapon = null;
    }
}
