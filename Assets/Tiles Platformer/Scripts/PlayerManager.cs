using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Cinemachine; 
public class PlayerManager : MonoBehaviour {
	public static bool isGameOver;
	public GameObject gameOverScreen;
	public GameObject pausemenuScreen;

	// for checkPoints
	public static Vector2 lastCheckPointPos = new Vector2(-8,3);
	//coins
	public static int numberOfCoins;
	public TextMeshProUGUI coinsText;
	//Players Array
	public GameObject[] playerPrefabs;
	int characterIndex;
	// vcam Follow
	public CinemachineVirtualCamera vcam1;
	
	void Awake()
    {
		if(SceneManager.GetActiveScene().buildIndex == 4)
        {
			lastCheckPointPos = new Vector2(-8, 3);
		}
		characterIndex =  PlayerPrefs.GetInt("SelectedCharacter", 0);
		
		GameObject player = Instantiate(playerPrefabs[characterIndex], lastCheckPointPos, Quaternion.identity);
		vcam1.m_Follow = player.transform;
		numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
		isGameOver = false;
			
		
    }
	
	
	// Update is called once per frame
	void Update () 
	{
		coinsText.text = numberOfCoins.ToString();
        if (isGameOver)
        {	
			
			gameOverScreen.SetActive(true);
        }
		
	}
	public void ReplayGame()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
	public void PauseGame()
    {
		Time.timeScale = 0;
		pausemenuScreen.SetActive(true);

    }
	public void ResumeGame()
    {
		Time.timeScale = 1;
		pausemenuScreen.SetActive(false);
    }
	public void GoTomenu(int index)
    {
		Time.timeScale = 1;
		SceneManager.LoadScene(index);
    }

}
