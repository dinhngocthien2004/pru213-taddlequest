using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game Stats")]
    [SerializeField] private int maxLives = 3;
    public int lives = 1;
    public int score = 0;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private GameObject gameOverUi;
    [SerializeField] private GameObject gameWinUi;

    private bool isGameOver = false;
    private bool isGameWin = false;

    private Vector3 checkpointPosition;
    private int checkpointScore;
    private int checkpointLives;
    private bool hasCheckpoint = false;


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
        lives = maxLives;
        UpdateLives();
        UpdateScore();             
        gameOverUi.SetActive(false);
        lives = PlayerPrefs.GetInt("Lives", 3);
    }

    private void UpdateLives()
    {
        livesText.text = "Lives: " + lives;
    }

    public void Addscore(int points)
    {
        if (!isGameOver && !isGameWin)
        {
            score += points;
            UpdateScore();
        }     
    }

    public void LoseLife()
    {
        if (isGameOver || isGameWin) return;

        lives--;
        UpdateLives();

        if (lives <= 0)
        {
            GameOver();
        }
        //else
        // {
        // Chưa hết mạng → chơi lại từ đầu màn
        //Time.timeScale = 1;
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoseAllLives()
    {
        if (isGameOver || isGameWin) return;

        lives = 0;
        UpdateLives();
        GameOver();
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }


    public void SaveCheckpoint(Vector3 position)
    {
        checkpointPosition = position;
        checkpointScore = score;
        checkpointLives = lives;
        hasCheckpoint = true;
    }

    public void ContinueFromCheckpoint()
    {
        if (!hasCheckpoint)
        {
            RestartGame();
            return;
        }

        isGameOver = false;
        Time.timeScale = 1;
        gameOverUi.SetActive(false);

        lives = checkpointLives;
        score = checkpointScore;

        UpdateLives();
        UpdateScore();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = checkpointPosition;
    }


    public void GameOver()
    {
        isGameOver = true;
        //score = 0;
        Time.timeScale = 0;
        gameOverUi.SetActive(true);
    }

    public void GameWin()
    {
        isGameWin = true;
        Time.timeScale = 0;
        gameWinUi.SetActive(true);
    }

    public void RestartGame()
    {
        isGameOver = false;
        isGameWin = false;
        score = 0;
        lives = maxLives;
        UpdateScore();
        UpdateLives();
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }

    public void RestartGame2()
    {
        isGameOver = false;
        isGameWin = false;
        score = 0;
        lives = maxLives;
        UpdateScore();
        UpdateLives();
        Time.timeScale = 1;
        SceneManager.LoadScene("Game2");
    }

    public void RestartGame3()
    {
        isGameOver = false;
        isGameWin = false;
        score = 0;
        lives = maxLives;
        UpdateScore();
        UpdateLives();
        Time.timeScale = 1;
        SceneManager.LoadScene("Game3");
    }

    public void GotoMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public bool IsGameWin()
    {
        return isGameWin;
    }

    public void PlayerDie()
    {
        lives--;

        PlayerPrefs.SetInt("Lives", lives);
        PlayerPrefs.Save();

        Debug.Log("Lives còn: " + lives);

        if (lives <= 0)
        {
            Debug.Log("Game Over");
        }
    }
}
