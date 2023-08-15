using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserHit : MonoBehaviour {

	public float weaponDamage = 5f;

	

	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag =="Enemy")
		{
			Destroy(gameObject);
			
			EnemyShipHealth hurtEnemy = other.gameObject.GetComponent<EnemyShipHealth>();
			hurtEnemy.AddDamage(weaponDamage);
			
		}

	}
	
}
