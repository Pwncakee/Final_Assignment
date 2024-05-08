using UnityEngine;

public class GatherableRock : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().GatherRock();
            Destroy(gameObject);
        }
    }
}

