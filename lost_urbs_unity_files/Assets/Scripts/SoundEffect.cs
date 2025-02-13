using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public AudioSource footStepsSound;
    public float walkSpeed = 3.0f; // Speed when walking
    public float runSpeed = 6.0f;  // Speed when running
    private float currentSpeed = 0f; // Current speed of the player
    private bool isRunning = false;
    private bool isWalking = false;
    private float fadeOutTime = 1.0f; // Duration for fade-out effect
    private float fadeOutTimer = 0f; // Timer for fade-out
    private float stepInterval = 0.5f; // Interval between steps (seconds)
    private float stepTimer = 0f; // Timer to manage step intervals


    void Update()
    {
        // Check if movement keys are pressed
        bool isMoving = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S);

        // Check if the shift key is held down to determine if the player is running
        isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        isWalking = !isRunning && isMoving; // Determine if the player is walking

        if (isMoving)
        {
            currentSpeed = isRunning ? runSpeed : walkSpeed;

            // If the footstep sound isn't playing, start it with a delay
            if (!footStepsSound.isPlaying)
            {
                footStepsSound.volume = 0.3f;
                footStepsSound.PlayDelayed(0.2f); // 0.2 second delay before sound starts
            }

            // Smoothly adjust the pitch based on whether the player is running or walking
            if (isRunning)
            {
                footStepsSound.pitch = Mathf.Lerp(footStepsSound.pitch, Random.Range(1.2f, 1.5f), Time.deltaTime * 10f); // Smooth transition for running
            }
            else if (isWalking)
            {
                footStepsSound.pitch = Mathf.Lerp(footStepsSound.pitch, Random.Range(0.8f, 1.0f), Time.deltaTime * 10f); // Smooth transition for walking
            }

            // Handle step interval based on movement speed
            stepTimer += Time.deltaTime;

            // If enough time has passed since the last step, play the next step
            if (stepTimer >= stepInterval)
            {
                stepTimer = 0f; // Reset the timer
                footStepsSound.Play(); // Play the step sound again to avoid pauses
            }

            // Adjust the step interval based on the player's speed
            if (isRunning)
            {
                stepInterval = 0.3f; // When the player is running, footsteps are more frequent
            }
            else
            {
                stepInterval = 0.6f; // When the player is walking, footsteps are less frequent
            } 
        }
        else
        {
            // Handle the fade-out effect if the player is not moving
            if (footStepsSound.isPlaying)
            {
                fadeOutTimer += Time.deltaTime;
                footStepsSound.volume = Mathf.Lerp(0.3f, 0f, fadeOutTimer / fadeOutTime); // Fade out the volume
                if (fadeOutTimer >= fadeOutTime)
                {
                    footStepsSound.Stop(); // Stop the sound completely after fading
                    fadeOutTimer = 0f; // Reset fade-out timer
                }
            }
        }
    }






    /*else
    {    
        footStepsSound.Stop(); //just in case sound is still playing
        targetVolume = 0f; // Fade out when stopping
    }

    // Smoothly adjust the volume
    footStepsSound.volume = Mathf.Lerp(footStepsSound.volume, targetVolume, Time.deltaTime * fadeSpeed);

    if (Input.GetKey(KeyCode.LeftShift))
    {
        isRunning = true;

    }
    else isRunning = false;*/
}
