using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    [SerializeField] Weapon currWeapon;

    [SerializeField] GameObject player;
    [SerializeField] GameObject weaponHolder;

    [SerializeField] Vector3 directionTowardsPlayer;

    private float distanceFromPlayer;
    private float attackRadius;
    private float speed;

    private float time;
    private float timer;
    private bool canShoot;

    public enemyState state;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(currWeapon);
        currWeapon.GetComponent<Rigidbody>().useGravity = false;
        currWeapon.transform.parent = weaponHolder.transform;
        currWeapon.transform.position = weaponHolder.transform.position;
        attackRadius = 15f;
        speed = 4;
    }

    // Update is called once per frame
    void Update()
    {
        distanceFromPlayer = Vector3.Distance(player.transform.position, gameObject.transform.position);

        if (distanceFromPlayer > attackRadius)
        {
            state = enemyState.Approaching;
        }
        else if (currWeapon.HasAmmo())
        {
            state = enemyState.Gunning;
        }
        else
        {
            state = enemyState.Meleeing;
        }

        switch (state)
        {
            case enemyState.Approaching:
                ApproachPlayer();
                break;
            case enemyState.Gunning:
                ShootPlayer();
                break;
            case enemyState.Meleeing:
                MeleePlayer();
                break;
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }

    private void ApproachPlayer()
    {
        transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void ShootPlayer()
    {
        PointWeaponAtPlayer();
        currWeapon.Shoot();
    }

    private void MeleePlayer()
    {
        ApproachPlayer();
    }

    private void PointWeaponAtPlayer()
    {
        currWeapon.gameObject.transform.LookAt(player.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over");
        }
    }
}

public enum enemyState
{
    Approaching,
    Gunning,
    Meleeing
}
