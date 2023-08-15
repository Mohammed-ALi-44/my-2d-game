using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShipHealth : MonoBehaviour {

	public float fullHealth;
	float currentHealth;
	///VFX &SFX
	public GameObject playerDeathvFX;
	public AudioClip playerDeathSFX;
	public GameObject hitVFX;
	public AudioClip hitSFX;
	public float sfxVolume = 0.5f;
	bool damaged;
	//Health UI
	public Text healthText;


	// Use this for initialization
	void Start()
	{
		currentHealth = fullHealth;
		
	}
	public void AddDamage(float damage)
	{
		if (damage <= 0) { return; }
		currentHealth -= damage;
		AudioSource.PlayClipAtPoint(hitSFX, Camera.main.transform.position, 0.15f);
		if (currentHealth <= 0)
		{
			MakeDead();
		}
	}
	public void MakeDead()
	{
		Instantiate(playerDeathvFX, transform.position, transform.rotation);
		AudioSource.PlayClipAtPoint(playerDeathSFX, Camera.main.transform.position, sfxVolume);
		ShipManager.isGameOver = true;
		Destroy(gameObject);
		
	}
	
	void OnTriggerEnter2D(Collider2D other)
    {
		if(other.tag=="EnemyLaser" )
        {
			Instantiate(hitVFX, transform.position, Quaternion.identity);

        }
    }
	void Update()
    {
		healthText.text = currentHealth.ToString();
    }
}
