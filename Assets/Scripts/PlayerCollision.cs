using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private bool isCollidingWithTerrain;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Apply movement or controls to the player here
        // ...
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("field"))
        {
            isCollidingWithTerrain = true;

            // Prevent the player from moving through the terrain
            playerRigidbody.velocity = Vector3.zero;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("field"))
        {
            isCollidingWithTerrain = false;
        }
    }
}
