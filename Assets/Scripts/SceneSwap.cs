using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{
    public void GoToStartMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void GoToPeriodicTable()
    {
        SceneManager.LoadScene("Periodic Table");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
