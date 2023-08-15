using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelsController : MonoBehaviour {

    public Button[] buttons;
    int unLockLevelsNum;

    void Start()
    {
        if (!PlayerPrefs.HasKey("LevelPassed"))
        {
            PlayerPrefs.SetInt("LevelPassed", 0);
        }
        unLockLevelsNum = PlayerPrefs.GetInt("LevelPassed");
        for(int i = 0; i < buttons.Length; i++)
        {
            if(unLockLevelsNum == 2) { return; }
            buttons[i].interactable = false;
        }
    }
    void Update()
    {
        unLockLevelsNum = PlayerPrefs.GetInt("LevelPassed");
        if (unLockLevelsNum > 1) { return; }
        for (int i =0; i<unLockLevelsNum; i++)
        {
            buttons[i].interactable = true;
            
            
        }

    }
    public void LevelToLoad(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteKey("LevelPassed");
    }
}
