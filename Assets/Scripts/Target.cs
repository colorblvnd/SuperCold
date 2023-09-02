using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Torch torch;
    private float randomXZBounds;
    private float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        randomXZBounds = 9;
        rotationSpeed = 400;
        transform.position = new Vector3(Random.Range(-randomXZBounds, randomXZBounds), Random.Range(0.4f, 5.3f), Random.Range(-randomXZBounds, randomXZBounds));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.unscaledDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player Bullet"))
        {
            Respawn();
            gameManager.TargetHit("Target Hit! +10", 10);
            torch.TargetHit();
        }
        else if (other.gameObject.CompareTag("Turret Bullet"))
        {
            Respawn();
            gameManager.TargetHit("Style Points! +50", 50);
            torch.TargetHit();
            Debug.Log(transform.position + "hit");
        }
    }

    private void Respawn()
    {
        transform.position = new Vector3(Random.Range(-randomXZBounds, randomXZBounds), Random.Range(0.4f, 5.3f), Random.Range(-randomXZBounds, randomXZBounds));
    }
}
