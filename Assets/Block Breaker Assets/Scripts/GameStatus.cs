using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour {
	// Score 
	[SerializeField] int currentScore = 0;
	[SerializeField] int ScorePointsPerBlockDestroyed = 0;
	[SerializeField] TextMeshProUGUI scoreText;
	void Awake()
    {
		int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
			Destroy(gameObject);

        }
        else
        {
			DontDestroyOnLoad(gameObject);

        }
    }
	void Start()
    {
		scoreText.text = currentScore.ToString();
    }
	
	// Update is called once per frame
	
	//Call this  from blocks.cs
	public void AddToScore()
    {
		currentScore += ScorePointsPerBlockDestroyed;
		//Each time increasing the score we need to update score value
		scoreText.text = currentScore.ToString();
    }
	public void Resetgame()
    {
		Destroy(gameObject);
    }
}
