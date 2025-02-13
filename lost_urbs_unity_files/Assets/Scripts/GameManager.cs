using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public TextMeshProUGUI scoreText; // Assign a UI text in Inspector
    private int score = 0;
    public int requiredScore = 1; // Set the required score to win the game

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int value)
    {
        score += value;
        if (scoreText != null)
            scoreText.text = "Score: " + score;
        else
            Debug.LogWarning("Score Text UI is not assigned in the Inspector!");
    }

    public int GetScore()
    {
        return score; // Returns the current score
    }

    public void EndGame()
    {
        Debug.Log("Game Over! You reached the required score.");
        SceneManager.LoadScene(2);
        // Implement game over logic, such as loading a new scene or showing UI
        //Time.timeScale = 0; // Pauses the game
    }
}