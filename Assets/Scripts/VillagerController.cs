using UnityEngine;
using System.Collections;

public class VillagerController : UnitBase {

	enum Mode
	{
		Wander,
		Follow,
		Flee
	}

	Mode currentMode;

	GameObject target;

	[SerializeField]
	float wanderSpeed = 0.05f;
	[SerializeField]
	float runSpeed = 1.2f;
	[SerializeField]
	float followSpeed = 1.0f;
	[SerializeField]
	float chanceToWander = 0.1f;
	[SerializeField]
	float chanceToStopWandering = 0.9f;

	Shapeshift shape;
	Shapeshift previousShape;

	bool inSanctuary = false;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine(StandCoroutine());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void OnPlayerTrigger (PlayerBase player, Shapeshift shape)
	{
		
		base.OnPlayerTrigger (player, shape);

		if (currentMode == Mode.Wander || shape != previousShape)
		{
			switch (shape) 
			{
			case Shapeshift.Human:
				if (inSanctuary) break;
				StopAllCoroutines();
				StartCoroutine(FollowCoroutine(player));
				break;
			case Shapeshift.Stag:
				if (inSanctuary) break;
				//target = player.gameObject;
				StopAllCoroutines();
				StartCoroutine(FollowCoroutine(player));
				break;
			case Shapeshift.Bear:
				StopAllCoroutines();
				StartCoroutine(FleeCoroutine(player.gameObject));
				break;
			default:
				break;
			}
			
		}

		previousShape = shape;
	}

	public override void OnSanctuaryTrigger(bool safe, GameObject go)
	{
		Debug.Log(safe);

		if (safe != inSanctuary && safe)
		{
			StopAllCoroutines();
			StartCoroutine(ShelterCoroutine(go.transform.position));
			
		}

		inSanctuary = safe;

		//if (safe)

	}

	IEnumerator StandCoroutine()
	{
		currentMode = Mode.Wander;

		yield return new WaitForSeconds(Random.Range(2.0f, 4.0f));

		StartCoroutine(WanderCoroutine());
	}

	IEnumerator WanderCoroutine()
	{
		currentMode = Mode.Wander;

		float startingTime = Time.time;
		float timeToWonder = Random.Range(1.0f, 3.0f);

		transform.RotateAround(transform.position, Vector3.up, Random.Range(0.0f, 360.0f));

		while (Time.time < startingTime + timeToWonder)
		{
			transform.Translate(Vector3.forward * wanderSpeed);
			yield return null;
		}
		StartCoroutine(StandCoroutine());
	}

	IEnumerator ShelterCoroutine(Vector3 target)
	{
		currentMode = Mode.Wander;

		float startingTime = Time.time;
		float timeToWonder = startingTime + Random.Range(3.0f, 5.0f);

		Vector3 vDirection = target - transform.position;
		float angle = Mathf.Sign(Vector3.Dot(vDirection, Vector3.right)) * Vector3.Angle(vDirection, Vector3.forward);
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);

		while (Time.time < timeToWonder)
		{
			transform.Translate(Vector3.forward * followSpeed);
			yield return null;
		}
		StartCoroutine(StandCoroutine());
	}

	IEnumerator FollowCoroutine(PlayerBase player)
	{
		currentMode = Mode.Follow;

		float distance = Vector3.Distance(transform.position, player.transform.position);

		while (distance > 3.0f && distance < 15.0f)//(true)//
		{
			Vector3 vDirection = player.transform.position - transform.position;
			float angle = Mathf.Sign(Vector3.Dot(vDirection, Vector3.right)) * Vector3.Angle(vDirection, Vector3.forward);
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);

			transform.Translate(Vector3.forward * followSpeed);

			yield return null;

			distance = Vector3.Distance(transform.position, player.transform.position);
		}

		StartCoroutine(StandCoroutine());
	}

	IEnumerator FleeCoroutine(GameObject target)
	{
		currentMode = Mode.Flee;

		float startingTime = Time.time;
		float timeToFlee = startingTime + Random.Range(1.0f, 3.0f);

		float distance = Vector3.Distance(transform.position, target.transform.position);

		Vector3 vDirection = target.transform.position - transform.position;
		float angle = Mathf.Sign(Vector3.Dot(vDirection, Vector3.right)) * Vector3.Angle(vDirection, Vector3.back);
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);



		while (Time.time < timeToFlee)//(true)//
		{
			transform.Translate(Vector3.forward * runSpeed);

			yield return null;

			//distance = Vector3.Distance(transform.position, player.transform.position);
		}

		StartCoroutine(StandCoroutine());

	}

}
