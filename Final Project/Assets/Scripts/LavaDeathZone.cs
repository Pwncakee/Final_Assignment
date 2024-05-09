using UnityEngine;

public class LavaDeathZone : MonoBehaviour
{
    public Transform respawnPoint;
    private string[] deathTags = { "Player", "death", "lava" };

    void OnTriggerEnter(Collider other)
    {
        foreach (string tag in deathTags)
        {
            if (other.gameObject.CompareTag(tag))
            {
                other.transform.position = respawnPoint.position;
                break;
            }
        }
    }
}


