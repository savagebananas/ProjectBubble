using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
	public GameObject startScreen;

	void QuitGame()
	{
		Application.Quit();
	}

	void StartGame()
	{
		SceneManager.LoadScene("SampleScene");
	}
}
