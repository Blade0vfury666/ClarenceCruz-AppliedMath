using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseScreen;

    public void PauseGame()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}