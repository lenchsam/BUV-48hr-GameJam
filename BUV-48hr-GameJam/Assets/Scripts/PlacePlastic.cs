using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePlastic : MonoBehaviour
{
    // The GameObject to be placed
    public GameObject objectToPlace;

    // The player GameObject
    public GameObject player;

    // Define the vertices of the polygonal area
    public Vector2[] polygonVertices;

    // Time interval between spawns
    public float spawnInterval = 5.0f;

    // List to keep track of spawned objects
    public List<GameObject> spawnedObjects = new List<GameObject>();

    // The closest object to the player
    public GameObject closestObject;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObjectsPeriodically());
    }

    IEnumerator SpawnObjectsPeriodically()
    {
        while (true)
        {
            PlaceObjectRandomly();
            yield return new WaitForSeconds(spawnInterval);
            FindClosestObjectToPlayer();
        }
    }

    void PlaceObjectRandomly()
    {
        Vector3 randomPosition;
        do
        {
            randomPosition = GenerateRandomPosition();
        } while (!IsPointInPolygon(new Vector2(randomPosition.x, randomPosition.z), polygonVertices));

        // Instantiate the object at the random position and add it to the list
        GameObject newObject = Instantiate(objectToPlace, randomPosition, Quaternion.identity);
        spawnedObjects.Add(newObject);
    }

    public void RemoveObject(GameObject obj)
    {
        spawnedObjects.Remove(obj);
        FindClosestObjectToPlayer(); // Recalculate the closest object
    }

    void FindClosestObjectToPlayer()
    {
        float closestDistance = float.MaxValue;
        closestObject = null;

        foreach (var obj in spawnedObjects)
        {
            float distance = Vector3.Distance(player.transform.position, obj.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestObject = obj;
            }
        }
    }

    Vector3 GenerateRandomPosition()
    {
        // Calculate the bounding box of the polygon
        float minX = float.MaxValue;
        float maxX = float.MinValue;
        float minZ = float.MaxValue;
        float maxZ = float.MinValue;

        foreach (var vertex in polygonVertices)
        {
            if (vertex.x < minX) minX = vertex.x;
            if (vertex.x > maxX) maxX = vertex.x;
            if (vertex.y < minZ) minZ = vertex.y;
            if (vertex.y > maxZ) maxZ = vertex.y;
        }

        // Generate random positions within the bounding box
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);

        return new Vector3(randomX, 0, randomZ);
    }

    bool IsPointInPolygon(Vector2 point, Vector2[] polygon)
    {
        int polygonLength = polygon.Length, i = 0;
        bool inside = false;
        // Get the angle between the point and the two vertices of each edge
        for (int j = polygonLength - 1; i < polygonLength; j = i++)
        {
            if (((polygon[i].y <= point.y && point.y < polygon[j].y) ||
                (polygon[j].y <= point.y && point.y < polygon[i].y)) &&
                (point.x < (polygon[j].x - polygon[i].x) * (point.y - polygon[i].y) / (polygon[j].y - polygon[i].y) + polygon[i].x))
            {
                inside = !inside;
            }
        }
        return inside;
    }
}
