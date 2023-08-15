using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHit : MonoBehaviour {
	public float swordDamage = 15f;
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other)
    {
		if (other.tag == "Enemy")
		{
			EnemyHealth hurtEnemy = other.gameObject.GetComponent<EnemyHealth>();
			hurtEnemy.AddDamage(swordDamage);
			Destroy(gameObject);
		}
	}void OnTriggerStay2D(Collider2D other)
    {
		if (other.tag == "Enemy")
		{
			EnemyHealth hurtEnemy = other.gameObject.GetComponent<EnemyHealth>();
			hurtEnemy.AddDamage(swordDamage);
			Destroy(gameObject);
		}
	}
}
