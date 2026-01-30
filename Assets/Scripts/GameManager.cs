using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game Stats")]
    [SerializeField] private int maxLives = 1;
    private int lives = 1;
    private int score = 0;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private GameObject gameOverUi;

    private bool isGameOver = false;

    private void Awake()
    {
        // Singleton đơn giản
        if (Instance == null)
        {
            Instance = this;
           // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // lives = maxLives;
        // Debug.Log("Lives = " + lives);
        UpdateScore();
        gameOverUi.SetActive(false);
    }

    public void Addscore(int points)
    {
        if (isGameOver) return;

        score += points;
        UpdateScore();
    }

    public void LoseLife()
    {
        if (isGameOver) return;

        lives--;

        if (lives <= 0)
        {
            GameOver();
        }
        else
        {
            // Chưa hết mạng → chơi lại từ đầu màn
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        isGameOver = true;
        score = 0;
        Time.timeScale = 0;
        gameOverUi.SetActive(true);
    }

    public void RestartGame()
    {
       // isGameOver = false;
       // score = 0;
       // lives = maxLives;

        // UpdateScore();

        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
}
