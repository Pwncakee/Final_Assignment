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

        if (Input.GetKeyDown(KeyCode.F) && Time.time >= lastThrowTime + 0.6f){

            lastThrowTime = Time.time;
            StartCoroutine(PowerThrowAction());
        }

        if (Input.GetKeyDown(KeyCode.C) && Time.time >= lastThrowTime + 0.6f){

            lastThrowTime = Time.time;
            StartCoroutine(LightThrowAction());
        }
        

    }

    IEnumerator PowerThrowAction()
{

    GetComponent<Animator>().SetTrigger("PowerThrow");

    yield return new WaitForSeconds(0.25f);

    GameObject rock = Instantiate(rockPrefab, RockSpawnPoint.position, Quaternion.identity);

    // Calculate throw direction based on player's forward direction and throw angle
    Vector3 throwDirection = Quaternion.AngleAxis(powerThrowAngle, transform.right) * transform.forward;

    // Apply force to the rock
    rock.GetComponent<Rigidbody>().AddForce(throwDirection * powerThrowForce, ForceMode.Impulse);

    Destroy(rock, 20f);
}

IEnumerator LightThrowAction()
{

    GetComponent<Animator>().SetTrigger("LightThrow");

    yield return new WaitForSeconds(0.45f);

    GameObject rock = Instantiate(rockPrefab, RockSpawnPoint.position, Quaternion.identity);

    // Calculate throw direction based on player's forward direction and throw angle
    Vector3 throwDirection = Quaternion.AngleAxis(lightThrowAngle, transform.right) * transform.forward;

    // Apply force to the rock
    rock.GetComponent<Rigidbody>().AddForce(throwDirection * lightThrowForce, ForceMode.Impulse);

    Destroy(rock, 20f);
}

}
