using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
	public GameObject pauseScreen;
    public GameObject gameOverScreen;
	public static bool isPaused;
    public PlayerOxygen Player;

    void Awake()
    {
        pauseScreen.SetActive(false);
        gameOverScreen.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        if(Player.oxygen <= 0)
        {
            GameOver();
        }
    }

    public void ResumeGame()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void PauseGame()
    {
    	pauseScreen.SetActive(true);
    	Time.timeScale = 0f; //pauses time in game
    	isPaused = true;
    }

    public void MainMenu()
    {
    	Time.timeScale = 1f;
    	SceneManager.LoadScene("MainMenu");
    }

    public void RetryGame()
    {
    	Scene currentScene = SceneManager.GetActiveScene();
    	SceneManager.LoadScene(currentScene.name);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }

}
