using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterShip : MonoBehaviour
// Use this for initialization
// Use this for initialization
{
	public float moveSpeed = 5f;
	//SetUpBoundaries params
	[SerializeField] float padding = .5f;
	float xMin, yMin, xMax, yMax;
	//Shooting
	[SerializeField] float projectileSpeed = 10f;
	[SerializeField] float projectileFiringPeriod = 0.1f;
	[SerializeField] GameObject projectile;
	Coroutine fireCoroutine;
	public GameObject projectile2;
	public float firePos;
	//Sfx
	public AudioClip shootSFX;
	public AudioClip shootSFX2;
	public float sfxVolume = 0.5f;
	public AudioClip switchSFX;
	//Swapping
	bool swap;
	void Start()
	{
		SetUpMoveBoundaries();
		swap = true;


	}

	// Update is called once per frame
	void Update()
	{
		Move();
		Fire();
		if (Input.GetKeyDown(KeyCode.V))
		{
			swap = !swap;
			AudioSource.PlayClipAtPoint(switchSFX, Camera.main.transform.position, sfxVolume);
		}

	}
	private void Move()
	{
		float moveHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
		float moveVertical = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
		float newXpos = Mathf.Clamp(transform.position.x + moveHorizontal, xMin, xMax);
		float newYpos = Mathf.Clamp(transform.position.y + moveVertical, yMin, yMax);
		transform.position = new Vector2(newXpos, newYpos);
	}
	void Fire()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			fireCoroutine = StartCoroutine(FireContinously());
		}
		if (Input.GetButtonUp("Fire1"))
		{
			StopCoroutine(fireCoroutine);
		}

	}
	void SetUpMoveBoundaries()
	{
		Camera gameCamera = Camera.main;
		xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
		xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
		yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
		yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;



	}
	IEnumerator FireContinously()
	{
		while (true)
		{
			if (swap)
			{
				GameObject laser = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
				laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, projectileSpeed);
				AudioSource.PlayClipAtPoint(shootSFX, Camera.main.transform.position, sfxVolume);
			}
			else
			{
				GameObject laser = Instantiate(projectile2, new Vector2(transform.position.x + firePos,transform.position.y  )  , Quaternion.identity) as GameObject;
				GameObject laser2 = Instantiate(projectile2, new Vector2(transform.position.x - firePos, transform.position.y), Quaternion.identity) as GameObject;
				laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, projectileSpeed);
				laser2.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, projectileSpeed);
				AudioSource.PlayClipAtPoint(shootSFX2, Camera.main.transform.position, sfxVolume);
				AudioSource.PlayClipAtPoint(shootSFX2, Camera.main.transform.position, sfxVolume);
			}
			yield return new WaitForSeconds(projectileFiringPeriod);
		}
	}


}
