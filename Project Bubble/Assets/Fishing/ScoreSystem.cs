using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
	public static ScoreSystem Instance; 

	[SerializeField]
	private TMP_Text scoreText;

	[SerializeField]
	private int score;

	void Awake()
	{
		if(Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}
	
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    	score = 0;
        scoreText.text = "Points: " + 0;
    }

    public void AddScore(int fishPoint)
    {
    	score += fishPoint;
    	scoreText.text = "Points: " + score.ToString();
    }
}
