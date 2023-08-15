using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRotaion : MonoBehaviour {
	public float rotationSpeed;
	// Use this for initialization
	void Start () 
	{
		GetComponent<Rigidbody2D>().angularVelocity = rotationSpeed;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
