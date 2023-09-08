using System.Collections.Generic;
using UnityEngine;

public class GreenTriballCatapult : MonoBehaviour
{
    private GameObject pickedObject; // The object the player is currently picking up
    private Vector3 offset = new Vector3(0f, 1f, 0f); // Offset for the picked object position
    private float teleportRange = 2.0f; // Range in units for teleporting the picked object

    private void Update()
    {
        if (pickedObject != null)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                TeleportObject();
            }
        }
    }

    private void TeleportObject()
    {
        if (pickedObject != null)
        {
            Vector3 teleportPosition = transform.position + (transform.forward * teleportRange);
            teleportPosition.y = transform.position.y; // Maintain the same Y position as the player
            pickedObject.transform.position = teleportPosition;
        }
    }
}
