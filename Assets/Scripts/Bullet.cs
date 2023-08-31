using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(Despawn), 6);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Turret"))
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Player"))
        {

        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            
        }
    }

    void Despawn()
    {
        Destroy(gameObject);
    }
}
