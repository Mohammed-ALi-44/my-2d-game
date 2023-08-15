using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
	public float enemyMaxhealth = 50f;
	float currentHealth;
	// VFXX 
	public GameObject enemyDeathVFX;
	//Sfx
	public AudioClip deathSFX;
	public AudioClip hurtSFX;
	//DROPS
	public bool drops;
	public GameObject theDrop;
	public static bool isAlive;
	void Start () 
	{
		currentHealth = enemyMaxhealth;

	
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void AddDamage(float damage)
    {
		AudioSource.PlayClipAtPoint(hurtSFX, Camera.main.transform.position, 0.2f);
		currentHealth -= damage;
        if (currentHealth < 0)
        {
			MakeDead();
        }
    }
	void MakeDead()
    {
        if (drops) Instantiate(theDrop,transform.position,transform.rotation);
		Instantiate(enemyDeathVFX, transform.position, transform.rotation);
		AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, 0.2f);
		Destroy(gameObject);

    }
}
