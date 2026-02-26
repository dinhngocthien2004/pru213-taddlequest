using UnityEngine;

public class SaveCoin : MonoBehaviour
{
    public GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager.score = GetScoreData();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SaveScoreData();
        }
    }
    void SaveScoreData()
    {
        PlayerPrefs.SetInt("Coin", gameManager.score);
        Debug.Log("Da luu");
        PlayerPrefs.Save();
    }
    int GetScoreData()
    {
        return PlayerPrefs.GetInt("Coin");
    }
}
