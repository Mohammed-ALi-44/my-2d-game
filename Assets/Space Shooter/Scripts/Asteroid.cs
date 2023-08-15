using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
	public float speed = 5f;
	public float rotationSpeed = 5f;

	// Use this for initialization
	void Start () 
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -speed);
		GetComponent<Rigidbody2D>().angularVelocity = rotationSpeed;
		
	}
	
	
	
}
