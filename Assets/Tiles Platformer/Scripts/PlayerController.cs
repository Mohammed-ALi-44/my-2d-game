using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	[Header("Run & Jump & Climb Speed Parameters")]
	public float runSpeed = 5f;
	public float jumpSpeed = 5f;
	public float climbSpeed = 4f;
	Rigidbody2D myRB;
	//***********************************
	[Header("Shooting Objects& Parameters")]
	public Transform bowTip;
	public GameObject arrow;
	float fireRate = 0.5f;
	float nextFire = 0f;


	Animator myAnim;
	bool isFacingRight;
	CapsuleCollider2D myBodyCollider;
	BoxCollider2D myFEET;
	public AudioClip jumpSFX;
	
	
	
	// Use this for initialization
	void Start () 
	{
		myRB = GetComponent<Rigidbody2D>();
		myAnim = GetComponent<Animator>();
		isFacingRight = true;
		myBodyCollider = GetComponent<CapsuleCollider2D>();
		myFEET = GetComponent<BoxCollider2D>();
		
	}
	private void Run()
    {
		// this param will store value between -1 , +1
		float move = Input.GetAxis("Horizontal");
		Vector2 playerVelocity = new Vector2(move *runSpeed,myRB.velocity.y);
		myRB.velocity = playerVelocity;
		bool playerHasHorizontalSpeed = Mathf.Abs(move) > Mathf.Epsilon;
		myAnim.SetBool("Running", playerHasHorizontalSpeed);
		if(move>0 && !isFacingRight)
        {
			FlipSprite();
        }
		else if( move<0 && isFacingRight)
        {
			FlipSprite();

        }
    }
	private void FlipSprite()
    {
		isFacingRight = !isFacingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

    }
	private void Jump()
    {
        if (!myFEET.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }
		
		// one click
        
		if (Input.GetButtonDown("Jump"))
        {
			Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
			myRB.velocity = jumpVelocity;
			AudioSource.PlayClipAtPoint(jumpSFX, Camera.main.transform.position, 0.1f);

        }
    }
	private void ClimbLadder()
    {
        //Check if the Player touching  ladder
        if (!myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Climbing"))) {
			myAnim.SetBool("Climbing",false);
			return; 
		}
		float moveupDown = Input.GetAxis("Vertical");
		Vector2 climbVelocity = new Vector2(myRB.velocity.x, moveupDown * climbSpeed);
		myRB.velocity = climbVelocity;
		bool playerhasVerticalSpeed = Mathf.Abs(myRB.velocity.y) > Mathf.Epsilon;
		myAnim.SetBool("Climbing", playerhasVerticalSpeed);
    }
	void FireArrow()
    {
        if (Time.time > nextFire)
        {	
			
			nextFire = Time.time + fireRate;
			myAnim.SetTrigger("Shoot");
			if (isFacingRight)
            {
				Instantiate(arrow, bowTip.position, Quaternion.Euler(new Vector3(0,0,0)));
			}else if (!isFacingRight)
            {
				Instantiate(arrow, bowTip.position, Quaternion.Euler(new Vector3(0, 0,180f)));

			}
        }
    }
	void Update()
    {
		Run();
		Jump();
		ClimbLadder();
        if (Input.GetAxisRaw("Fire1") > 0)
        {
			FireArrow();

        }
	}
}
