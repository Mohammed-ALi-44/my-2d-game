using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour {
	public float fullHealth;
	float currentHealth;
	// to stop player from moving after death 
	PlayerController controlMovment;
	public GameObject playerDeathvFX;
	Animator myAnim;
	//HUD VARIABLES

	public Slider healthSlider;
	// Damage Indicator
	Color damagedColor = new Color(100f, 500f, 0f, 0.7f);
	public Image damageScreen;
	float smoothColor =5f;
	bool damaged = false;
	//Audio SfX
	public AudioClip playerHurt;
	public AudioClip playerDeath;
	AudioSource playerAS;




	// Use this for initialization
	void Start () {
		currentHealth = fullHealth;
		controlMovment = GetComponent<PlayerController>();
		myAnim = GetComponent<Animator>();
		//HUD initialization
		healthSlider.maxValue = fullHealth;
		healthSlider.value=fullHealth;
		//Audio
		playerAS = GetComponent<AudioSource>();

	}
	public void AddDamage(float damage)
    {
        if (damage <= 0) { return; }
		currentHealth -= damage;
		playerAS.PlayOneShot(playerHurt);
		damaged = true;
		healthSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
			MakeDead();
        }
    }
	public void AddHealth(float healthAmount)
    {
		currentHealth += healthAmount;
        if (currentHealth > fullHealth)
        {
			currentHealth = fullHealth;
        }
		healthSlider.value = currentHealth;
	}
	public void MakeDead()
    {
		Instantiate(playerDeathvFX, transform.position, transform.rotation);
		AudioSource.PlayClipAtPoint(playerDeath, Camera.main.transform.position, 0.15f);
		Destroy(gameObject);
		damageScreen.color = damagedColor;
		PlayerManager.isGameOver = true;
	}
	
	// Update is called once per frame
	void Update()
    {
        if (damaged)
        {
			damageScreen.color = damagedColor;

        }
        else
        {
			damageScreen.color = Color.Lerp(damageScreen.color,Color.clear,smoothColor*Time.deltaTime);
        }
		damaged = false;
    }
}
