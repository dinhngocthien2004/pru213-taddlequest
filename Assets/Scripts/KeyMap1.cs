using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyMap1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Chuyển sang Scene 2
            SceneManager.LoadScene("Game2");
        }
    }
}
