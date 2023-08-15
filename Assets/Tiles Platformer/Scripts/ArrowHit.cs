using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHit : MonoBehaviour {
	public float weaponDamage= 5f;
	//Reference For the whole Arrow
	projectileController myPC;
	public GameObject arrowExplosionVfx;
	Collider2D mycoll;

	// Use this for initialization
	void Awake () 
	{
		myPC = GetComponentInParent<projectileController>();
		mycoll = GetComponent<BoxCollider2D>();
		
		
	}

	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Shootable")|| other.gameObject.layer == LayerMask.NameToLayer("Ground"))
		{
			myPC.RemoveForce();
			Instantiate(arrowExplosionVfx, transform.position, transform.rotation);
			Destroy(gameObject);
			if (other.tag == "Enemy")
			{
				EnemyHealth hurtEnemy = other.gameObject.GetComponent<EnemyHealth>();
				hurtEnemy.AddDamage(weaponDamage);
			}
		}
		
	}
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Shootable") || other.gameObject.layer == LayerMask.NameToLayer("Ground"))
		{
			myPC.RemoveForce();
			Instantiate(arrowExplosionVfx, transform.position, transform.rotation);
			Destroy(gameObject);
			if (other.tag == "Enemy")
			{
				EnemyHealth hurtEnemy = other.gameObject.GetComponent<EnemyHealth>();
				hurtEnemy.AddDamage(weaponDamage);
			}
		}
	}
}
