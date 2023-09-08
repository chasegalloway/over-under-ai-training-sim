using UnityEngine;

public class MatchloadZoneCollisionDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "BlueMatchloadZone")
        {
            Debug.Log("Player is in contact with a BlueMatchloadZone.");
        }
        else if (other.gameObject.name == "RedMatchloadZone")
        {
            Debug.Log("Player is in contact with a RedMatchloadZone.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "BlueMatchloadZone")
        {
            Debug.Log("Player is in contact with a BlueMatchloadZone.");
        }
        else if (other.gameObject.name == "RedMatchloadZone")
        {
            Debug.Log("Player is in contact with a RedMatchloadZone.");
        }
    }
}
