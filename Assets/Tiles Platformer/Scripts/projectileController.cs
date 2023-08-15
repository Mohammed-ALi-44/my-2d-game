using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour {
	Rigidbody2D myRB;
	public float projectileSpeed;
	// Use this for initialization
	void Awake () {
		myRB = GetComponent<Rigidbody2D>();
        if (transform.localRotation.z > 0)
		{ 
			myRB.AddForce(new Vector2(-1, 0) * projectileSpeed,ForceMode2D.Impulse);
		}
		else
        {
			myRB.AddForce(new Vector2(1, 0) * projectileSpeed, ForceMode2D.Impulse);
		}
	}
	public void RemoveForce()
    {
		myRB.velocity = new Vector2(0,0);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
