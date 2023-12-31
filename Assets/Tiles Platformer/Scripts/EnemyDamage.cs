﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {
	public float damage;
	public float damageRate;
	public float pushForce;
	float nextDamage;
	// Use this for initialization
	void Start () {
		nextDamage = 0f;
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player" && nextDamage < Time.time)
		{
			PlayerHealth thePlayerHealth = other.gameObject.GetComponent<PlayerHealth>();
			thePlayerHealth.AddDamage(damage);
			nextDamage = Time.time + damageRate;
			PushBack(other.transform);
		}

	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && nextDamage < Time.time)
		{
			PlayerHealth thePlayerHealth = other.gameObject.GetComponent<PlayerHealth>();
			thePlayerHealth.AddDamage(damage);
			nextDamage = Time.time + damageRate;
			PushBack(other.transform);
		}

	}
	void PushBack(Transform pushedObject) 
	{
		Vector2 pushDirection = new Vector2(0,(pushedObject.position.y-transform.position.y)).normalized;
		pushDirection *= pushForce;
		Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
		pushRB.velocity = Vector2.zero;
		pushRB.AddForce(pushDirection, ForceMode2D.Impulse);

	}

	// Update is called once per frame
	void Update () {
		
	}
}
