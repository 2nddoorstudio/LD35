﻿using UnityEngine;
using System.Collections;

public class TextureScroll : MonoBehaviour {

	[SerializeField]
	Renderer render;

	[SerializeField]
	float offsetX = 0.01f;
	[SerializeField]
	float offsetY = 0.01f;
	[SerializeField]
	float speedX = 0.9f;
	[SerializeField]
	float speedY = 0.9f;

	// Use this for initialization
	void Start () 
	{
		
	}

	// Update is called once per frame
	void Update () 
	{
		float x = Mathf.Sin(Time.time * speedX) * offsetX;
		float y = Mathf.Sin(Time.time * speedY) * offsetY;

		render.material.SetTextureOffset("_DetailAlbedoMap", new Vector2(x, y));
	}
}