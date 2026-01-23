using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameManager gameManager;
    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject); 
            gameManager.Addscore(1);
            //Debug.Log("Hit Coin");
        }
        else if (collision.CompareTag("Trap"))
        {
            Debug.Log("UI dau qua di");
        }
    }

}
