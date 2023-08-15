using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEvents : MonoBehaviour 
{
	public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Quit()
    {
        Application.Quit();

    }
    public void Money()
    {
        PlayerPrefs.SetInt("NumberOfCoins", 130);
    }

}
