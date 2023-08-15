using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour 
{
    public static bool gameIsPAused = false;
    public GameObject pauseMenuUI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPAused)
            {
                Resume();
            }
            else
            {
                Pause();

            }

        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPAused = false;

    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPAused = true;
    }
  
     public void Quit()
    {
        Application.Quit();


    }
    public void LoadMenu(int index)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(index);
    }

}
