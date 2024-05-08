using UnityEngine;

public class LavaDeathZone : MonoBehaviour
{
    public Transform respawnPoint;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.position = respawnPoint.position;
            
        }
    }
}

