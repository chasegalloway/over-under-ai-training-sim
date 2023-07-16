using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int redScore = 0;
    private int blueScore = 0;
    private float collisionTolerance = 0.1f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Green Triball")
        {
            Debug.Log("Collision Detected");

            if (IsCollidingWithScoreZone(collision.gameObject, "RedScoreZone"))
            {
                redScore++;
                Debug.Log("Red Score: " + redScore);
            }
            else if (IsCollidingWithScoreZone(collision.gameObject, "BlueScoreZone"))
            {
                blueScore++;
                Debug.Log("Blue Score: " + blueScore);
            }
        }
    }

    private bool IsCollidingWithScoreZone(GameObject obj, string scoreZoneName)
    {
        Collider objCollider = obj.GetComponent<Collider>();
        GameObject scoreZone = GameObject.Find(scoreZoneName);

        if (scoreZone == null)
        {
            Debug.LogError("Score zone object not found: " + scoreZoneName);
            return false;
        }

        Collider scoreZoneCollider = scoreZone.GetComponent<Collider>();

        if (scoreZoneCollider == null)
        {
            Debug.LogError("Collider not found on score zone object: " + scoreZoneName);
            return false;
        }

        Bounds objBounds = objCollider.bounds;
        Bounds scoreZoneBounds = scoreZoneCollider.bounds;

        bool isColliding = objBounds.Intersects(scoreZoneBounds) ||
            objBounds.Intersects(ExpandedBounds(scoreZoneBounds, collisionTolerance));

        if (isColliding)
        {
            Debug.Log(obj.name + " is colliding with " + scoreZoneName);
        }

        return isColliding;
    }

    private Bounds ExpandedBounds(Bounds bounds, float amount)
    {
        return new Bounds(bounds.center, bounds.size + Vector3.one * amount);
    }
}
