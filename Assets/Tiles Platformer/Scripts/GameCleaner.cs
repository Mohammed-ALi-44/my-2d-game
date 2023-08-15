using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCleaner : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerHealth playerFell = other.gameObject.GetComponent<PlayerHealth>();
            playerFell.MakeDead();
             
        }
        else
        {
            Destroy(other.gameObject);
        }
    }

	
}
