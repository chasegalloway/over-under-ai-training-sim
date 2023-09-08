using UnityEngine;

public class ScoreZoneCollisionDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "BlueScoreZone")
        {
            Debug.Log("Player is in contact with a BlueScoreZone.");
        }
        else if (other.gameObject.name == "RedScoreZone")
        {
            Debug.Log("Player is in contact with a RedScoreZone.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "BlueScoreZone")
        {
            Debug.Log("Player is no longer in contact with a BlueScoreZone.");
        }
        else if (other.gameObject.name == "RedScoreZone")
        {
            Debug.Log("Player is no longer in contact with a RedScoreZone.");
        }
    }
}
