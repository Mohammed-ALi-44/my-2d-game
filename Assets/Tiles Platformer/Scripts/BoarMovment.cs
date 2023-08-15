using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarMovment : MonoBehaviour {
	public float boarSpeed;
	Animator enemyAnim;
	// Flip child GameObject
	public GameObject enemyGraphic;
	bool canFlip = true;
	bool facingRight = false;
	float flipTime = 5f;
	float nextFlipChance;
	public float chargeTime;
	// when the player enter the collider (Attack time after entering)

	float startChargeTime;
	bool charging;
	Rigidbody2D enemyRB;
	EnemyHealth health;
	// Use this for initialization
	void Start () 
	{
		enemyAnim = GetComponentInChildren<Animator>();
		enemyRB = GetComponent<Rigidbody2D>();
		health = GetComponentInChildren<EnemyHealth>();
		nextFlipChance = 0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!health) return;
		if(Time.time > nextFlipChance)
        {
            if (Random.Range(0, 10)>=5)
            {
				FlipFacing();


            }
			nextFlipChance = Time.time + flipTime;
        }
	}
	void FlipFacing()
    {
		if (!health) return;
		if (!canFlip) return;
		float facingX = enemyGraphic.transform.localScale.x;
		facingX *= -1f;
		enemyGraphic.transform.localScale = new Vector3(facingX, enemyGraphic.transform.localScale.y, enemyGraphic.transform.localScale.z);
		facingRight = !facingRight;
    }
	void OnTriggerEnter2D(Collider2D other)
    {
		if (!health) return;
		if (other.tag == "Player")
        {
			if (facingRight && other.transform.position.x < transform.position.x)
			{
				FlipFacing();
			}
			else if (!facingRight && other.transform.position.x > transform.position.x)
            {
				FlipFacing();
            }
        }
		canFlip = false;
		charging = true;
		startChargeTime = Time.time + chargeTime;

    }
	void OnTriggerStay2D(Collider2D other)
    {
		if (!health) return;
		if (other.tag == "Player")
        {
			if(startChargeTime < Time.time)
            {
				if (!facingRight) enemyRB.velocity = new Vector2(-boarSpeed, 0f);
				else enemyRB.velocity = new Vector2(boarSpeed, 0f);
				
				
				enemyAnim.SetBool("isCharging", charging);

            }
        }
    }
	void OnTriggerExit2D(Collider2D other)
    {
		if (!health) return;
		if (other.tag == "Player")
        {
			canFlip = true;
			charging = false;
			enemyRB.velocity = new Vector2(0f, 0f);
			enemyAnim.SetBool("isCharging", charging);
        }
    }
}
