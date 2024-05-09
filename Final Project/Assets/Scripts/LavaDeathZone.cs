using UnityEngine;

public class LavaDeathZone : MonoBehaviour
{
    public Transform respawnPoint;
    public AudioClip deathSound; // The sound that will play upon death
    private AudioSource audioSource; // The source from which the sound will play
    private string[] deathTags = { "Player", "death", "lava" };

    void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        foreach (string tag in deathTags)
        {
            if (other.gameObject.CompareTag(tag))
            {
                other.transform.position = respawnPoint.position;
                
                audioSource.PlayOneShot(deathSound);
                break;
            }
        }
    }
}



