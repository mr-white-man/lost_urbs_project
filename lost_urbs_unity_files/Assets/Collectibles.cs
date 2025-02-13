using UnityEngine;

public class Collectible : MonoBehaviour
{
    public AudioClip collectSound; // Optional: Assign a sound effect
    public int scoreValue = 1; // Points to add when collected

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the player collects it
        {
            if (collectSound != null)
                AudioSource.PlayClipAtPoint(collectSound, transform.position); // Play sound

            GameManager.instance.AddScore(scoreValue); // Add score (optional)
            Destroy(gameObject); // Remove the collectible
        }
    }
}
