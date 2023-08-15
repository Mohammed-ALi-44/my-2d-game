using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelect : MonoBehaviour {

	// Use this for initialization
	public GameObject[] skins;
	public int selectedCharacter;
	// for shop
	public Character[] characters;
	public Button unLockButton;
	//coins
	public TextMeshProUGUI coinsText;
	private void Awake()
    {
		selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
		foreach(GameObject player in skins)
        {
			player.SetActive(false);
        }
		skins[selectedCharacter].SetActive(true);
		foreach(Character c in characters)
        {
			if(c.price == 0)
            {
				c.isUnLocked = true;
            }
            else
            {
				c.isUnLocked = PlayerPrefs.GetInt(c.name, 0) == 0 ? false : true;
            }
        }
		
      
		UpdateUI();

	}
	public void ChangeNext()
    {
		skins[selectedCharacter].SetActive(false);
		selectedCharacter++;
		if(selectedCharacter == skins.Length)
        {
			selectedCharacter = 0;
        }
		skins[selectedCharacter].SetActive(true);
		if (characters[selectedCharacter].isUnLocked)
			PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
		UpdateUI();
	}
	public void ChangePrevious()
    {
		skins[selectedCharacter].SetActive(false);
		selectedCharacter--;
		if(selectedCharacter == -1)
        {
			selectedCharacter = skins.Length-1;
        }
		skins[selectedCharacter].SetActive(true);
		if(characters[selectedCharacter].isUnLocked)
			PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
		UpdateUI();
	}
	public void UpdateUI()
    {
		coinsText.text = "Coins :" + PlayerPrefs.GetInt("NumberOfCoins", 0);
		if(characters[selectedCharacter].isUnLocked == true)
        {
			unLockButton.gameObject.SetActive(false);
        }
        else
        {
			unLockButton.GetComponentInChildren<TextMeshProUGUI>().text = "Price:" + characters[selectedCharacter].price;
			if(PlayerPrefs.GetInt("NumberOfCoins",0) < characters[selectedCharacter].price)
            {
				unLockButton.gameObject.SetActive(true);
				unLockButton.interactable = false;
            }
            else
            {
				unLockButton.gameObject.SetActive(true);
				unLockButton.interactable = true;

			}
        }
    }
	public void UnLock()
    {
		int coins = PlayerPrefs.GetInt("NumberOfCoins", 0);
		int price = characters[selectedCharacter].price;
		PlayerPrefs.SetInt("NumberOfCoins", coins - price);
		PlayerPrefs.SetInt(characters[selectedCharacter].name, 1);
		PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
		characters[selectedCharacter].isUnLocked = true;
		UpdateUI();

	}
}
