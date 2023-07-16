using System.Collections.Generic;
using UnityEngine;

public class PlayerPickupGreen : MonoBehaviour
{
    private GameObject pickedObject; // The object the player is currently picking up
    private bool isTeleporting; // Flag to indicate if teleportation is happening
    private Vector3 offset = new Vector3(0f, 1f, 0f); // Offset for the picked object position

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Green Triball")
        {
            if (pickedObject == null && !isTeleporting)
            {
                pickedObject = other.gameObject;
                pickedObject.SetActive(false); // Disable the object temporarily
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == pickedObject)
        {
            pickedObject = null;
        }
    }

    private void Update()
    {
        if (pickedObject == null && Input.GetKeyDown(KeyCode.P)) // Change KeyCode.P to the desired input key for picking up
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 0.5f); // Adjust the radius as needed
            foreach (Collider collider in colliders)
            {
                if (collider.gameObject.name == "Green Triball")
                {
                    pickedObject = collider.gameObject;
                    pickedObject.SetActive(false); // Disable the object temporarily
                    break;
                }
            }
        }
        else if (pickedObject != null && Input.GetKeyDown(KeyCode.Return)) // Change KeyCode.Return to the desired input key for dropping
        {
            DropObject();
        }
    }

    private void DropObject()
    {
        if (pickedObject != null)
        {
            pickedObject.SetActive(true);
            pickedObject.transform.position = transform.position + offset;
            pickedObject.transform.parent = null;
            pickedObject = null;
        }
    }

    private void LateUpdate()
    {
        if (isTeleporting)
        {
            if (pickedObject != null)
            {
                Vector3 targetPosition = transform.position + offset;
                targetPosition.y = pickedObject.transform.position.y; // Maintain the same Y position as the object
                pickedObject.transform.position = targetPosition;
            }
        }
    }
}
