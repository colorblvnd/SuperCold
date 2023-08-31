using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AmmunitionPile : XRBaseInteractable
{
    [SerializeField] GameObject handGameObject;
    [SerializeField] Hands rightHand;
    [SerializeField] LerpColor lerper;

    private float cooldown;

    private bool onCooldown;

    // Start is called before the first frame update
    void Start()
    {
        rightHand = handGameObject.GetComponent<Hands>();
        cooldown = 10;
        onCooldown = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        if (!onCooldown && rightHand.hasWeapon)
        {
            Debug.Log("interacted properly");
            lerper.BeginLerp();
            rightHand.currWeapon.RefillAmmo();
            onCooldown = true;
            Invoke(nameof(AmmoCooldown), cooldown);
        }
    }

    private void AmmoCooldown()
    {
        onCooldown = false;
    }
}
