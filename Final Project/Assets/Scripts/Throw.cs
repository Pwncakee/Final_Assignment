using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public PlayerController playerController;
    public float powerThrowForce = 20f;
    public float powerThrowAngle = 330f;

    public float lightThrowForce = 10f;
    public float lightThrowAngle = 330f;
    public GameObject rockPrefab;

    public Transform RockSpawnPoint;

    private Animator animator;

    private float lastThrowTime;

    void Update()
    {
        if (playerController.rockCount <= 0)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.F) && Time.time >= lastThrowTime + 0.6f){
            
            lastThrowTime = Time.time;
            StartCoroutine(PowerThrowAction());
            playerController.rockCount--;
        }

        if (Input.GetKeyDown(KeyCode.C) && Time.time >= lastThrowTime + 0.6f){
            
            lastThrowTime = Time.time;
            StartCoroutine(LightThrowAction());
            playerController.rockCount--;
        }
        

    }

    IEnumerator PowerThrowAction()
{
    GetComponent<Animator>().SetTrigger("PowerThrow");

    yield return new WaitForSeconds(0.25f);

    Vector3 spawnPosition = RockSpawnPoint.position;

        // Perform a raycast down to the ground
    RaycastHit hit;
    if (Physics.Raycast(spawnPosition + Vector3.up * 50, Vector3.down, out hit, 100f))
        {
            // If the raycast hit the ground, set the spawn position to the hit point
        spawnPosition = hit.point;
        }

    GameObject rock = Instantiate(rockPrefab, spawnPosition, Quaternion.identity);
    rock.AddComponent<GatherableRock>();
    rock.GetComponent<GatherableRock>().playerController = playerController;

    SphereCollider triggerCollider = rock.AddComponent<SphereCollider>();
    triggerCollider.isTrigger = true;

        // Calculate throw direction based on player's forward direction and throw angle
    Vector3 throwDirection = Quaternion.AngleAxis(powerThrowAngle, transform.right) * transform.forward;

    // Apply force to the rock
    rock.GetComponent<Rigidbody>().AddForce(throwDirection * powerThrowForce, ForceMode.Impulse);

    //playerController.rockCount--;
}

IEnumerator LightThrowAction()
{
    GetComponent<Animator>().SetTrigger("LightThrow");

    yield return new WaitForSeconds(0.45f);

    Vector3 spawnPosition = RockSpawnPoint.position;

        // Perform a raycast down to the ground
    RaycastHit hit;
    if (Physics.Raycast(spawnPosition + Vector3.up * 50, Vector3.down, out hit, 100f))
        {
            // If the raycast hit the ground, set the spawn position to the hit point
        spawnPosition = hit.point;
        }
    GameObject rock = Instantiate(rockPrefab, spawnPosition, Quaternion.identity);
    rock.AddComponent<GatherableRock>();
    rock.GetComponent<GatherableRock>().playerController = playerController;

    SphereCollider triggerCollider = rock.AddComponent<SphereCollider>();
    triggerCollider.isTrigger = true;
        // Calculate throw direction based on player's forward direction and throw angle
    Vector3 throwDirection = Quaternion.AngleAxis(lightThrowAngle, transform.right) * transform.forward;

    // Apply force to the rock
    rock.GetComponent<Rigidbody>().AddForce(throwDirection * lightThrowForce, ForceMode.Impulse);


    //playerController.rockCount--;
}

}
