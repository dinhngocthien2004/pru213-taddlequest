using UnityEngine;

public class GameOver: MonoBehaviour
{
    public AudioSource audioSource;

    void OnEnable()
    {
        audioSource.Play();
    }
}