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
        Collider scoreZoneCollider = scoreZone.GetComponent<Collider>();

        Bounds objBounds = objCollider.bounds;
        Bounds scoreZoneBounds = scoreZoneCollider.bounds;

        return objBounds.Intersects(scoreZoneBounds) ||
               objBounds.Intersects(ExpandedBounds(scoreZoneBounds, collisionTolerance));
    }

    private Bounds ExpandedBounds(Bounds bounds, float amount)
    {
        return new Bounds(bounds.center, bounds.size + Vector3.one * amount);
    }
}
