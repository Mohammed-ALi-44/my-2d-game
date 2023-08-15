using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
	public float screenWidthInUnits = 20f;
	float xmin;
	float xmax;
	public float padding = 1f;
	// Use this for initialization
	void Start () {
		SetUpMoveBoundaries();
	}
	
	// Update is called once per frame
	void Update () {
		float mousePosInUnits = Input.mousePosition.x / Screen.width*screenWidthInUnits  ;
		Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
		paddlePos.x = Mathf.Clamp(mousePosInUnits, xmin, xmax);
		transform.position = paddlePos;
	}
    void SetUpMoveBoundaries()
    {
		Camera gameCamera = Camera.main;
		xmin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
		xmax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
    } 
}
