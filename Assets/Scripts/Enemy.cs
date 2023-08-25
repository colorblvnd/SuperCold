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

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(currWeapon);
        currWeapon.GetComponent<Rigidbody>().useGravity = false;
        currWeapon.transform.parent = weaponHolder.transform;
        currWeapon.transform.position = weaponHolder.transform.position;
        attackRadius = 15f;
        time = 0;
        timer = 1;
        speed = 4;
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > timer)
        {
            time = 0;
            canShoot = true;
        }

        currWeapon.gameObject.transform.LookAt(player.transform);

        distanceFromPlayer = Vector3.Distance(player.transform.position, gameObject.transform.position);
        if (distanceFromPlayer > attackRadius)
        {
            ApproachPlayer();
        }
        else
        {
            AttackPlayer();
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

    private void AttackPlayer()
    {
        if (canShoot)
        {
            PointWeaponAtPlayer();
            currWeapon.Shoot();
            canShoot = false;
        }
    }

    private void PointWeaponAtPlayer()
    {
        directionTowardsPlayer = (player.transform.position - transform.position).normalized;
        Debug.Log(directionTowardsPlayer);

    }
}
