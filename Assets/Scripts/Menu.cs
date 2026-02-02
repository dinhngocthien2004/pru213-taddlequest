using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
   public void PlayGame()
   {
        SceneManager.LoadScene("Game");
   }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void GameGuide()
    {
        SceneManager.LoadScene("Guide");
    }
    public void GameMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
