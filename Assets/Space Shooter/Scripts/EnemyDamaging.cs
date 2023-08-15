using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamaging : MonoBehaviour {

	
	


	public float damage = 5f;
	public float damageRate = 0.5f;
	public float nextDamage;
	// Use this for initialization
	void Start () 
	{
		nextDamage = 0f;
		
	}
	void OnTriggerEnter2D(Collider2D other)
    {
		if (other.gameObject.tag == "Player" && nextDamage < Time.time)
		{

			PlayerShipHealth playerShip = other.gameObject.GetComponent<PlayerShipHealth>();
			playerShip.AddDamage(damage);
			nextDamage = Time.time + damageRate;

		}
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
