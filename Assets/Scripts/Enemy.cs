using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float distance = 4f;
    private Vector3 startPos;
    private bool movingRight = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float leftBound = startPos.x - distance;
        float rightBound = startPos.x + distance;
        if(movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if(transform.position.x >= rightBound)
            {
                movingRight = false;
                Flip();
            }    
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if(transform.position.x <= leftBound)
            {
                movingRight = true;
                Flip();
            }    
        }
    }
    void Flip()
    {
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        foreach (ContactPoint2D contact in collision.contacts)
        {
            // Player đạp từ TRÊN xuống
            if (contact.normal.y < -0.5f)
            {
                // Bật Player lên
                Rigidbody2D playerRb =
                    collision.gameObject.GetComponent<Rigidbody2D>();

                playerRb.linearVelocity =
                    new Vector2(playerRb.linearVelocity.x, 8f);

                // Enemy chết
                Destroy(gameObject);
                return;
            }
        }
        // Không phải đạp đầu → Player chết
        PlayerCollision playerCollision = collision.gameObject.GetComponent<PlayerCollision>();

        if (playerCollision != null)
        {
            playerCollision.TakeDamage();
        }

    }

}
