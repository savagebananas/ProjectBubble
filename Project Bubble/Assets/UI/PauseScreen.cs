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

    public static bool timePaused;

    void Awake()
    {
        pauseScreen.SetActive(false);
        gameOverScreen.SetActive(false);
    }

    private void Start()
    {
        isPaused = false;
        timePaused = false;
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
        isPaused = false;
        timePaused = false;
    }

    public void PauseGame()
    {
    	pauseScreen.SetActive(true);
    	isPaused = true;
        timePaused = true;
    }

    public void MainMenu()
    {
    	//Time.timeScale = 1f;
    	SceneManager.LoadScene("MainMenu");
    }

    public void RetryGame()
    {
        //Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
    	SceneManager.LoadScene(currentScene.name);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        timePaused = true;
        //Time.timeScale = 0f;
    }

}
