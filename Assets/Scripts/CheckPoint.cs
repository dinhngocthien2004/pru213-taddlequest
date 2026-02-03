using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Something entered checkpoint");

        if (!collision.CompareTag("Player")) return;

        Debug.Log("Player touched checkpoint");

        GameManager.Instance.SaveCheckpoint(transform.position);

        // Tắt collider để không lưu nhiều lần
        GetComponent<Collider2D>().enabled = false;
    }
}
