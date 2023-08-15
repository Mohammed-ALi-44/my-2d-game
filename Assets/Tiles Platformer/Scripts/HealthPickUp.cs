using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour 
{
    public AudioClip healthSFX;
    public float healthAmount;
    void OnTriggerEnter2D( Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerHealth theHealth = other.gameObject.GetComponent<PlayerHealth>();
            theHealth.AddHealth(healthAmount);
            AudioSource.PlayClipAtPoint(healthSFX, Camera.main.transform.position, 0.5f);
            Destroy(gameObject);
        }
    }


}
