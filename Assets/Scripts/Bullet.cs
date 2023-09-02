using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public float despawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        despawnTimer = 6f;
        Invoke(nameof(Despawn), despawnTimer);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HeadScript>().HeadHit();
            Destroy(gameObject);
        }
    }

    void Despawn()
    {
        Destroy(gameObject);
    }
}
