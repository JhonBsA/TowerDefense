using UnityEngine;

[RequireComponent(typeof(EnemyBase))]
public class EnemyMovement : MonoBehaviour
{
    
    public float turnSpeed = 20f;
    public float waypointThreshold = 0.23f; // Distance threshold to reach the waypoint

    private EnemyBase _enemy;

    private Transform target; // Target waypoint
    private int waypointIndex = 0;

    void Start()
    {
        _enemy = GetComponent<EnemyBase>();
        target = Waypoint.waypoints[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position; // Points from target.position to transform.position
        dir.y = 0; // Ensures enemy doesn't move in "y" axis
        transform.Translate(dir.normalized * _enemy.speed * Time.deltaTime, Space.World); // Translates enemy to normalized direction at "speed"

        if (dir != Vector3.zero) // Check if there's a direction
        {
            // Calculate the target rotation
            Quaternion lookRotation = Quaternion.LookRotation(dir);

            // Round to the nearest 90 degrees
            Vector3 roundedEuler = RoundToNearest90(lookRotation.eulerAngles);
            Quaternion roundedRotation = Quaternion.Euler(roundedEuler);

            // Rotate towards the rounded direction
            transform.rotation = Quaternion.Slerp(transform.rotation, roundedRotation, Time.deltaTime * turnSpeed);
        }

        if (Vector3.Distance(transform.position, target.position) <= waypointThreshold) // If enemy is close enough to waypoint
        {
            GetNextWaypoint();
        }

        _enemy.speed = _enemy.startSpeed;

    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoint.waypoints.Length - 1)
        {
            EndPath();
            return;
        }
        waypointIndex++;
        target = Waypoint.waypoints[waypointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
        WaveSpawner.EnemiesAlive--;
    }

    Vector3 RoundToNearest90(Vector3 eulerAngles)
    {
        // Rounds each component to the nearest 90 degrees
        eulerAngles.x = Mathf.Round(eulerAngles.x / 90) * 90;
        eulerAngles.y = Mathf.Round(eulerAngles.y / 90) * 90;
        eulerAngles.z = Mathf.Round(eulerAngles.z / 90) * 90;
        return eulerAngles;
    }
}
