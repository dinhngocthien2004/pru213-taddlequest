using UnityEngine;

public class SaveLives : MonoBehaviour
{
    public GameManager gameManager;

    void Start()
    {
        if (gameManager != null)
        {
            gameManager.lives = GetLiveData();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SaveLiveData();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            DeleteData();
        }
    }

    void SaveLiveData()
    {
        PlayerPrefs.SetInt("Lives", gameManager.lives);
        PlayerPrefs.Save();

        Debug.Log("Save Lives thành công: " + gameManager.lives);
    }

    int GetLiveData()
    {
        // Nếu chưa có dữ liệu sẽ trả về 3 mạng
        return PlayerPrefs.GetInt("Lives", 3);
    }

    void DeleteData()
    {
        PlayerPrefs.DeleteKey("Lives");
        Debug.Log("Đã xóa dữ liệu Lives");
    }
}
