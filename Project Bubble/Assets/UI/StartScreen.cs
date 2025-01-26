using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
	public GameObject startScreen;
	public GameObject howToPlay;
	public AudioSource bubblePop;

	public void QuitGame()
	{
		Application.Quit();
	}

	public void StartGame()
	{
		bubblePop.Play();
		SceneManager.LoadScene("SampleScene");
	}

	public void Info()
	{
		bubblePop.Play();
		howToPlay.SetActive(true);
	}

	public void Back()
	{
		bubblePop.Play();
		howToPlay.SetActive(false);
	}

	void Start()
	{
		howToPlay.SetActive(false);
	}
}
