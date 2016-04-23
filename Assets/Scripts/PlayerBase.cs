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

	//[SerializeField]
	//Renderer render;

	[SerializeField]
	GameObject druidPrefab;
	[SerializeField]
	GameObject bearPrefab;
	[SerializeField]
	GameObject stagPrefab;

	GameObject currentPrefab;

	[SerializeField]
	GameObject transformParticles;

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
	public override void Start () {
		base.Start();

		ChangePrefab(Shapeshift.Human);

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

	void ChangePrefab(Shapeshift shape)
	{
		if (shape == Shapeshift.Human)
		{
			currentPrefab = druidPrefab;
			druidPrefab.SetActive(true);
			bearPrefab.SetActive(false);
			stagPrefab.SetActive(false);
		}

		if (shape == Shapeshift.Stag)
		{
			currentPrefab = stagPrefab;
			stagPrefab.SetActive(true);
			druidPrefab.SetActive(false);
			bearPrefab.SetActive(false);
		}

		if (shape == Shapeshift.Bear)
		{
			currentPrefab = bearPrefab;
			bearPrefab.SetActive(true);
			druidPrefab.SetActive(false);
			stagPrefab.SetActive(false);
		}

		animator = currentPrefab.GetComponent<Animator>();

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
//		Vector2 v1 = Camera.main.WorldToViewportPoint(transform.position);
//		Vector2 v2 = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
//
//		float angle = Mathf.Atan2(v1.y - v2.y, v1.x - v2.x) * Mathf.Rad2Deg;
//		transform.rotation = Quaternion.Euler (new Vector3(0f, -(angle - Camera.main.transform.parent.transform.rotation.eulerAngles.y + 90.0f), 0f));

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
		if (currentShape != shape) {	// Prevents stutter and unneeded smoke puff if we're already in the chosen form

			if (isTransforming)
				return;

			isTransforming = true;

			GameObject go = Instantiate(transformParticles);
			go.transform.position = transform.position;

			switch (shape) 
			{
			case Shapeshift.Human:
				ChangePrefab(Shapeshift.Human);
				movementSpeed = humanMovementSpeed;
				//newTextureSliderA = 0.0f;
				//newTextureSliderB = 0.0f;
				break;
			case Shapeshift.Stag:
				ChangePrefab(Shapeshift.Stag);
				movementSpeed = stagMovementSpeed;
				//newTextureSliderA = 1.0f;
				//newTextureSliderB = 0.0f;
				break;
			case Shapeshift.Bear:
				ChangePrefab(Shapeshift.Bear);
				movementSpeed = bearMovementSpeed;
				//newTextureSliderA = 1.0f;
				//newTextureSliderB = 1.0f;
				break;
			default:
				break;
			}

			currentShape = shape;
			currentBehaviour = UpdateTransform;
			StartCoroutine(Transformation());

		}

	}

	//TODO: change transformation-- maybe one for each transition
	IEnumerator Transformation()
	{
		float startTime = Time.time;
		float endTime = startTime + transformationDuration;

		//Material material = render.material;

		while(Time.time < endTime)
		{
			//float t = Mathf.InverseLerp(startTime, endTime, Time.time);

			//material.SetFloat("_TransitionA", Mathf.Lerp(textureSliderA, newTextureSliderA, t));
			//material.SetFloat("_TransitionB", Mathf.Lerp(textureSliderB, newTextureSliderB, t));

			yield return null;
		}

		textureSliderA = newTextureSliderA;

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
			animator.SetFloat("AnimSpeed", 1.0f);
		}
		else
			animator.SetFloat("AnimSpeed", 0.0f);
	}

	void UpdateStag()
	{
		if (Input.GetButton("Fire1"))
		{
			MoveForward(stagMovementSpeed);
			animator.SetFloat("AnimSpeed", 1.0f);
		}
		else
			animator.SetFloat("AnimSpeed", 0.0f);
	}

	void UpdateBear()
	{
		if (Input.GetButton("Fire1"))
		{
			MoveForward(bearMovementSpeed);
			animator.SetFloat("AnimSpeed", 1.0f);
		}
		else
			animator.SetFloat("AnimSpeed", 0.0f);
	}

	void OnTriggerStay(Collider other) {

		UnitBase unit = other.gameObject.GetComponent<UnitBase>();

		if (unit == null)
			return;
		
		unit.OnPlayerTrigger(this, currentShape);

	}

	void OnTriggerEnter(Collider other)	//Stay(Collider other)
	{
		UnitBase unit = other.gameObject.GetComponent<UnitBase>();

		if (unit == null)
			return;
		
		unit.OnPlayerEnter(this, currentShape);

	}
}
