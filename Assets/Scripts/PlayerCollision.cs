using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameManager gameManager;
    private AudioManager audioManager;
    private bool isInvincible = false;
    [SerializeField] private float invincibleTime = 0.5f;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            audioManager.PlayCoinSound();
            gameManager.Addscore(1);
        }
        else if (collision.CompareTag("Trap"))
        {
            if (isInvincible) return;

            gameManager.LoseLife();
            StartCoroutine(InvincibleCoroutine());
        }

        else if (collision.CompareTag("KillZone"))
        {
            gameManager.LoseAllLives(); // chết ngay
        }
        else if (collision.CompareTag("Enemy"))
        {
            gameManager.GameOver(); // chết ngay
        }

        else if (collision.CompareTag("Key"))
        {
            Destroy(collision.gameObject);
            gameManager.GameWin();
        }
    }
    private System.Collections.IEnumerator InvincibleCoroutine()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibleTime);
        isInvincible = false;
    }
    public void TakeDamage()
    {
        if (isInvincible) return;

        gameManager.LoseLife();
        StartCoroutine(InvincibleCoroutine());
    }


}
