using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSelect : MonoBehaviour {
	public GameObject[] skins;
	public int selectedShip;


	void Awake()
    {
		selectedShip = PlayerPrefs.GetInt("SelectedShip", 0);
		foreach(GameObject ship in skins)
        {
			ship.SetActive(false);
        }
		skins[selectedShip].SetActive(true);
    }


	public void ChangeNext()
    {
		skins[selectedShip].SetActive(false);
		selectedShip++;
		if(selectedShip == skins.Length)
        {
			selectedShip = 0;
        }
		skins[selectedShip].SetActive(true);
		PlayerPrefs.SetInt("SelectedShip",selectedShip);
    }
	public void ChangePrevious()
    {
		skins[selectedShip].SetActive(false);
		selectedShip--;
		if (selectedShip == -1)
		{
			selectedShip = skins.Length-1;
		}
		skins[selectedShip].SetActive(true);
		PlayerPrefs.SetInt("SelectedShip", selectedShip);
	}
}
