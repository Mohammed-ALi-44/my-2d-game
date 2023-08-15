using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipHealth : MonoBehaviour {

	// Use this for initialization
	public float enemyMaxhealth = 50f;
	float currentHealth;
	// VFXX 
	public GameObject enemyDeathVFX;
	//SfX
	[SerializeField] AudioClip deathSFX;
	[SerializeField] float sfxVolume =  0.5f;
	// Use this for initialization
	void Start()
	{
		currentHealth = enemyMaxhealth;



	}

	// Update is called once per frame
	
	public void AddDamage(float damage)
	{
		currentHealth -= damage;
		if (currentHealth < 0)
		{
			MakeDead();
		}
	}
	void MakeDead()
	{
		Instantiate(enemyDeathVFX, transform.position, transform.rotation);
		AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, sfxVolume);

		Destroy(gameObject);

	}
}
