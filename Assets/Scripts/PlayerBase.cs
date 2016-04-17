using UnityEngine;
using System;
using System.Collections;

public enum Shapeshift {
	Human,
	Bear,
	Stag
}


// Base class for player; can transform, attack
public class PlayerBase : UnitBase {

	#region "Class Vars"

	Renderer render;

	// transformation vars

	bool isTransforming = false;

	public Shapeshift currentShape;

	[SerializeField]
	float movementSpeed = 0.2f;

	[SerializeField]
	float transformationDuration = 2.0f;

	Action currentBehaviour;

	float textureSliderA = 0.0f;
	float textureSliderB = 0.0f;
	float newTextureSliderA = 0.0f;
	float newTextureSliderB = 0.0f;

	Vector3 newPosition = Vector3.zero;

	#endregion

	// Use this for initialization
	void Start () {
		currentShape = Shapeshift.Human;

		render = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Material material = render.material;

		//Debug.Log(material.name);

		if (Input.GetKeyDown(KeyCode.A))
		{
			InitTransform(Shapeshift.Human);
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			InitTransform(Shapeshift.Stag);
		}
		if (Input.GetKeyDown(KeyCode.D))
		{
			InitTransform(Shapeshift.Bear);
		}

		Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		Physics.Raycast(mouseRay, out hit);

		Vector2 v1 = Camera.main.WorldToViewportPoint(transform.position);
		Vector2 v2 = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

		float angle = Mathf.Atan2(v1.y - v2.y, v1.x - v2.x) * Mathf.Rad2Deg;

		transform.rotation = Quaternion.Euler (new Vector3(0f, -(angle + 90f), 0f));

		if (Input.GetButton("Fire1"))
		{
			newPosition = hit.point;

			//MoveTo(newPosition);
			transform.Translate(Vector3.forward * movementSpeed);
		}


	}

	void InitTransform(Shapeshift shape)
	{
		if (isTransforming)
			return;

		isTransforming = true;

		switch (shape) 
		{
		case Shapeshift.Human:
			newTextureSliderA = 0.0f;
			newTextureSliderB = 0.0f;
			break;
		case Shapeshift.Stag:
			newTextureSliderA = 1.0f;
			newTextureSliderB = 0.0f;
			break;
		case Shapeshift.Bear:
			newTextureSliderA = 1.0f;
			newTextureSliderB = 1.0f;
			break;
		default:
			break;
		}

		currentShape = shape;
		currentBehaviour = UpdateTransform;
		StartCoroutine(Transformation());
	}

	IEnumerator Transformation()
	{
		float startTime = Time.time;
		float endTime = startTime + transformationDuration;

		Material material = render.material;

		while(Time.time < endTime)
		{
			float t = Mathf.InverseLerp(startTime, endTime, Time.time);

			material.SetFloat("_TransitionA", Mathf.Lerp(textureSliderA, newTextureSliderA, t));
			material.SetFloat("_TransitionB", Mathf.Lerp(textureSliderB, newTextureSliderB, t));

			yield return null;
		}

		textureSliderA = newTextureSliderA;
		textureSliderB = newTextureSliderB;

		switch (currentShape) 
		{
		case Shapeshift.Human:
			currentBehaviour = UpdateHuman;
			break;
		case Shapeshift.Stag:
			currentBehaviour = UpdateStag;
			break;
		case Shapeshift.Bear:
			currentBehaviour = UpdateBear;
			break;
		default:
			break;
		}

		isTransforming = false;
	}

	void UpdateTransform()
	{
		
	}

	void UpdateHuman()
	{
		
	}

	void UpdateStag()
	{
		
	}

	void UpdateBear()
	{
		
	}
}
