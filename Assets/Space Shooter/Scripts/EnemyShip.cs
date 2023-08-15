using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour {

	public float speed = 5f;

	// Use this for initialization
	void Start()
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -speed);

	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "PlayerLaser")
		{
			Destroy(gameObject);
			Destroy(other.gameObject);
		}
		if (other.gameObject.tag == "Player")
		{
			Destroy(other.gameObject);
		}
	}

}
