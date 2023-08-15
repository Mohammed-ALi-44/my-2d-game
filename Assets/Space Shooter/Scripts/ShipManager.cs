using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ShipManager : MonoBehaviour {
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public GameObject winGameScreen;
    public GameObject[] shipsPrefabs;
    int shipIndex;
    void Awake()
    {
        isGameOver = false;
        shipIndex = PlayerPrefs.GetInt("SelectedShip",0);
        GameObject ship = Instantiate(shipsPrefabs[shipIndex],new Vector2(0,-6.5f),Quaternion.identity);

    }
    void Update()
    {
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);

        }
    }
    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadNextLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void LoadSceneIndex(int index)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(index);
    }
}
