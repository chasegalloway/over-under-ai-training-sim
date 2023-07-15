using System.Collections.Generic;
using UnityEngine;

public class PlayerPickupGreen : MonoBehaviour
{
    private List<GameObject> pickedObjects = new List<GameObject>(); // List of objects the player is currently picking up
    private bool isTeleporting; // Flag to indicate if teleportation is happening
    private Vector3 offset = new Vector3(0f, 1f, 0f); // Offset for the picked object position

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Green Triball")
        {
            if (!pickedObjects.Contains(other.gameObject) && !isTeleporting)
            {
                pickedObjects.Add(other.gameObject);
                other.gameObject.SetActive(false); // Disable the object temporarily
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Green Triball")
        {
            if (pickedObjects.Contains(other.gameObject) && !isTeleporting)
            {
                pickedObjects.Remove(other.gameObject);
                other.gameObject.SetActive(true); // Enable the object again
            }
        }
    }

    private void Update()
    {
        if (pickedObjects.Count > 0 && Input.GetKeyDown(KeyCode.P)) // Change KeyCode.P to the desired input key for picking up
        {
            if (!isTeleporting)
            {
                isTeleporting = true;
                StartCoroutine(TeleportObjects());
            }
        }
        else if (pickedObjects.Count > 0 && Input.GetKeyDown(KeyCode.Return)) // Change KeyCode.Return to the desired input key for dropping
        {
            StopTeleportation();
        }
    }

    private System.Collections.IEnumerator TeleportObjects()
    {
        while (isTeleporting)
        {
            foreach (GameObject pickedObject in pickedObjects)
            {
                Vector3 targetPosition = transform.position + offset;
                targetPosition.y = transform.position.y; // Maintain the same Y position as the player
                pickedObject.transform.position = targetPosition;
            }
            yield return null;
        }
    }

    private void StopTeleportation()
    {
        isTeleporting = false;
        foreach (GameObject pickedObject in pickedObjects)
        {
            pickedObject.SetActive(true);
            pickedObject.transform.position = transform.position + offset;
            pickedObject.transform.parent = null;
        }
        pickedObjects.Clear();
    }

    private void LateUpdate()
    {
        if (isTeleporting)
        {
            foreach (GameObject pickedObject in pickedObjects)
            {
                Vector3 targetPosition = transform.position + offset;
                targetPosition.y = pickedObject.transform.position.y; // Maintain the same Y position as the object
                pickedObject.transform.position = targetPosition;
            }
        }
    }
}
