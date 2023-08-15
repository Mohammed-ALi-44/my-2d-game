using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public Paddle paddle1;
	//Distance between paddle and ball
	Vector2 paddleToBallVector;
	bool hasStarted;
	// for push force
	[SerializeField] float xPush = 2f;
	[SerializeField] float yPush = 15f;
	//
	[SerializeField] float randomFactor = 0.2f;
	AudioSource myAudioSource;
	Rigidbody2D myRB; 

	void Start () {
		paddleToBallVector = transform.position - paddle1.transform.position;
		hasStarted = false;
		myAudioSource = GetComponent<AudioSource>();
		myRB = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
		if (! hasStarted)
		{

			LockPaddleToBall();
			LaunchOnMouseClick();
		}
	}
	private void  LockPaddleToBall()
    {

		Vector2 paddlePos = paddle1.transform.position;
		transform.position = paddlePos + paddleToBallVector;
	}

	private void LaunchOnMouseClick() 
	{
        //the parameter for the left button
        if (Input.GetMouseButtonDown(0))
        {
			hasStarted = true;
			myRB.velocity = new Vector2(xPush, yPush);

        }
		
	
	}
	private void OnCollisionEnter2D(Collision2D collision)
    {
		Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor)); 
		if (hasStarted)
		{
			myAudioSource.Play();
			myRB.velocity += velocityTweak;
			

		}
    }

}
