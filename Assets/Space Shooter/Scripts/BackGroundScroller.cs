﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroller : MonoBehaviour {
	[SerializeField]float scrollSpeed = 0.5f;
	Material myMaterial;
	Vector2 offset;
	// Use this for initialization
	void Start () 
	{
		myMaterial = GetComponent<Renderer>().material;
		offset = new Vector2(0, scrollSpeed);
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		myMaterial.mainTextureOffset  += offset*Time.deltaTime;
		
	}
}
