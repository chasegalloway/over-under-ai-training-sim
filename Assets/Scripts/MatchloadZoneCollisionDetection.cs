using UnityEngine;

public class MatchloadZoneCollisionDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "BlueMatchloadZone")
        {
            Debug.Log("Player is in contact with a Blue Matchload Zone.");
        }
        else if (other.gameObject.name == "RedMatchloadZone")
        {
            Debug.Log("Player is in contact with a Red Matchload Zone.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "BlueMatchloadZone")
        {
            Debug.Log("Player is in contact with a Blue Matchload Zone.");
        }
        else if (other.gameObject.name == "RedMatchloadZone")
        {
            Debug.Log("Player is in contact with a Red Matchload Zone.");
        }
    }
}
