using System.Collections;
using UnityEngine;

public class SaveNotificationUI : MonoBehaviour
{
    public GameObject savePanel; // kéo SaveNotification Panel vào đây

    void Start()
    {
        savePanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SaveGame();
            StartCoroutine(ShowSaveNotification());
        }
    }

    void SaveGame()
    {
        // Lưu dữ liệu từ GameManager       
        PlayerPrefs.SetInt("Score", GameManager.Instance.checkpointScore);
        PlayerPrefs.SetInt("Lives", GameManager.Instance.checkpointLives);
        PlayerPrefs.Save();

        Debug.Log("Game Saved!");
    }

    IEnumerator ShowSaveNotification()
    {
        savePanel.SetActive(true);
        yield return new WaitForSeconds(2f);
        savePanel.SetActive(false);
    }
}
