using UnityEngine;

public class EndGameTrigger : MonoBehaviour
{
    private bool playerInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true; // Mark that the player is inside the trigger
            Debug.Log("Press 'E' to end the game if you have enough points!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false; // Reset when the player leaves
        }
    }

    private void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E)) // Press E while inside
        {
            if (GameManager.instance.GetScore() >= GameManager.instance.requiredScore)
            {
                GameManager.instance.EndGame(); // Ends the game if the score is high enough
            }
            else
            {
                Debug.Log("You need more points to finish the game!");
            }
        }
    }
}

