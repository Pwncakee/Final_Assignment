using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject rockPrefab;
    public int numberOfRocks = 50;
    public float spawnRadius = 10f;
    public PlayerController playerController;

    void Start()
    {
        for (int i = 0; i < 50; i++)
        {
            SpawnRock();
        }
    }

    void SpawnRock()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnRadius, spawnRadius), 50, Random.Range(-spawnRadius, spawnRadius));
        RaycastHit hit;
        if (Physics.Raycast(spawnPosition, Vector3.down, out hit, 100f))
        {
            // If the raycast hit the ground, set the spawn position to the hit point
            spawnPosition = hit.point;
        }
        GameObject rock = Instantiate(rockPrefab, spawnPosition, Quaternion.identity);
        rock.AddComponent<GatherableRock>();
        rock.GetComponent<GatherableRock>().playerController = playerController;

        SphereCollider triggerCollider = rock.AddComponent<SphereCollider>();
        triggerCollider.isTrigger = true;
    }

}

