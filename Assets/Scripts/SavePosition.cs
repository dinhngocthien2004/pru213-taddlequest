using UnityEngine;

public class SavePosition : MonoBehaviour
{
    private Vector3 startPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {

            startPosition = transform.position;
        }
        else
        {
            LoadPlayerPosition();
        }
    }
    void OnApplicationQuit()
    {
        SavePlayerPosition();
    }
    public void SavePlayerPosition()
    {
        Vector3 playerPosition = transform.position;
        PlayerPrefs.SetFloat("PlayerX", transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", transform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", transform.position.z);
        PlayerPrefs.Save();
    }
    public void LoadPlayerPosition()
    {
        if (PlayerPrefs.HasKey("PlayerX") && PlayerPrefs.HasKey("PlayerY") && PlayerPrefs.HasKey("PlayerZ"))
        {
            float x = PlayerPrefs.GetFloat("PlayerX");
            float y = PlayerPrefs.GetFloat("PlayerY");
            float z = PlayerPrefs.GetFloat("PlayerZ");
            transform.position = new Vector3(x, y, z);
        }
    }
    //public void Die()
    //{
    //    Respawn();
    //}

    //void Respawn()
    //{
    //    transform.position = startPosition;
    //}

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Obstacle"))
    //    {
    //        GetComponent<SavePosition>().Die();
    //    }
    //}

}
