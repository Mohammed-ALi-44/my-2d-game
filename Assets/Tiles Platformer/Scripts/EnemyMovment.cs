using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour {
	Rigidbody2D myRB;
	[SerializeField] float moveSpeed = 1f;


	void Start () 
	{
		myRB = GetComponent<Rigidbody2D>();
		
			
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (IsFacingRight())
        {
			myRB.velocity = new Vector2(moveSpeed, 0f);

        }
        else
        {
			myRB.velocity = new Vector2(-moveSpeed, 0f);
        }
	}
	void OnTriggerExit2D(Collider2D collision) 
	{
		transform.localScale = new Vector2(-(Mathf.Sign(myRB.velocity.x)),1f);

	}
	bool IsFacingRight()
    {
		return transform.localScale.x > 0;
    }
}
