using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] Transform[] waypoints; // Array of waypoints
    [SerializeField] float speed = 2f; // Speed of enemy movement
    [SerializeField] float waypointTolerance = 0.1f; // Distance at which enemy considers it has reached a waypoint
    [SerializeField] GameObject objectToPlace; // The GameObject to place around the enemy
    [SerializeField] float placementInterval = 2f; // Interval in seconds between placing objects
    [SerializeField] float placementRadius = 5f; // Radius around the enemy to place objects

    private int currentWaypointIndex = 0;
    private float nextPlacementTime = 0f;

    private void Update()
    {
        patrol();
        PlaceObjectAroundEnemy();
    }

    private void patrol()
    {
        if (waypoints.Length == 0) return;

        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector3 direction = (targetWaypoint.position - transform.position).normalized;
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        // Check if the enemy is close enough to the waypoint to consider it reached
        if (Vector3.Distance(transform.position, targetWaypoint.position) < waypointTolerance)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length; // Move to the next waypoint, loop back to start
        }
    }

    private void PlaceObjectAroundEnemy()
    {
        if (Time.time >= nextPlacementTime)
        {
            Vector3 randomPosition = GetRandomPositionAroundEnemy();
            GameObject placedObject = Instantiate(objectToPlace, randomPosition, Quaternion.identity);
            ChangeObjectColor(placedObject);
            nextPlacementTime = Time.time + placementInterval;
        }
    }

    private Vector3 GetRandomPositionAroundEnemy()
    {
        Vector2 randomPoint = Random.insideUnitCircle * placementRadius;
        Vector3 randomPosition = new Vector3(randomPoint.x, 0, randomPoint.y) + transform.position;
        return randomPosition;
    }

    private void ChangeObjectColor(GameObject obj)
    {
        Renderer objRenderer = obj.GetComponent<Renderer>();
        if (objRenderer != null)
        {
            objRenderer.material.color = new Color(Random.value, Random.value, Random.value);
        }
    }
}
