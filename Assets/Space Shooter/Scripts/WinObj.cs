using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinObj : MonoBehaviour {
    public GameObject winScreen;
    int numberOfUnlockedLevels;
    public int levelToUnlock;
	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
           numberOfUnlockedLevels = PlayerPrefs.GetInt("LevelPassed");
           if(numberOfUnlockedLevels <= levelToUnlock)
           {
                PlayerPrefs.SetInt("LevelPassed", numberOfUnlockedLevels + 1);
                other.gameObject.SetActive(false);
                 
           }
            Time.timeScale = 0;
            winScreen.SetActive(true);

        }
    }
}
