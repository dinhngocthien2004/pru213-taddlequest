using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            gameManager.Addscore(1);
        }
        else if (
    collision.CompareTag("Trap") ||
    collision.CompareTag("KillZone")
)
        {
            gameManager.LoseLife();
        }

        else if (collision.CompareTag("Key"))
        {
            Destroy(collision.gameObject);
            gameManager.GameWin();
        }
    }
}
