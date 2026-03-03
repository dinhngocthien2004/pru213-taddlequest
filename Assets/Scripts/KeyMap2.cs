using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyMap2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Chuyển sang Scene 3
            SceneManager.LoadScene("Game3");
        }
    }
}
