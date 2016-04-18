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

	[SerializeField]
	Renderer render;

	float humanDamage = 0.35f;
	float stagDamage = 0.5f;
	float bearDamage = 0.2f;

	bool isTransforming = false;

	public Shapeshift currentShape;

	[SerializeField]
	float humanMovementSpeed = 0.2f;
	[SerializeField]
	float stagMovementSpeed = 0.3f;
	[SerializeField]
	float bearMovementSpeed = 0.1f;

	[SerializeField]
	float transformationDuration = 2.0f;

	float textureSliderA = 0.0f;
	float textureSliderB = 0.0f;
	float newTextureSliderA = 0.0f;
	float newTextureSliderB = 0.0f;

	Vector3 newPosition = Vector3.zero;

	Rigidbody rBody;

	#endregion

	// Use this for initialization
	void Start () {
		currentHealth = MaxHealth;
		damageMultiplier = humanDamage;
		currentShape = Shapeshift.Human;
		currentBehaviour = UpdateHuman;

		rBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	public override void Update () 
	{
		base.Update();

	}

	public override void UpdateLogic ()
	{
		base.UpdateLogic ();

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


		//Rotate to face mouse
		Vector2 v1 = Camera.main.WorldToViewportPoint(transform.position);
		Vector2 v2 = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

		float angle = Mathf.Atan2(v1.y - v2.y, v1.x - v2.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (new Vector3(0f, -(angle - Camera.main.transform.parent.transform.rotation.eulerAngles.y + 90.0f), 0f));

		//base.Update();
		//if (currentBehaviour != null)
		//	currentBehaviour();

		/*Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		Physics.Raycast(mouseRay, out hit);

		if (Input.GetButton("Fire1"))
		{
			//newPosition = hit.point;

			transform.Translate(Vector3.forward * humanMovementSpeed);
			//MoveTo(newPosition);
		}*/
		//if (Vector3.Distance(transform.position, hit.point) > 1.0f)

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

	//TODO: change transformation-- maybe one for each transition
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
		if (Input.GetButton("Fire1"))
		{
			MoveForward(humanMovementSpeed);
		}
	}

	void UpdateStag()
	{
		if (Input.GetButton("Fire1"))
		{
			MoveForward(stagMovementSpeed);
		}
	}

	void UpdateBear()
	{
		if (Input.GetButton("Fire1"))
		{
			MoveForward(bearMovementSpeed);
		}
	}

	void OnTriggerStay(Collider other)
	{
		UnitBase unit = other.gameObject.GetComponent<UnitBase>();

		if (unit == null)
			return;
		
		unit.OnPlayerTrigger(this, currentShape);

	}
}
