using UnityEngine;

public class GatherableRock : MonoBehaviour
{
    public bool isBeingThrown = false;
    public PlayerController playerController;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerController.rockCount++;
            Destroy(gameObject);

        }
    }
}


