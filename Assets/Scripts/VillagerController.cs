using UnityEngine;
using System.Collections;


public class VillagerController : UnitBase {


	[SerializeField]
	float wanderSpeed = 0.05f;
	[SerializeField]
	float runSpeed = 0.15f;
	[SerializeField]
	float followSpeed = 0.1f;

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
		base.Update();
	}

	public override void OnPlayerTrigger (PlayerBase player, Shapeshift shape)
	{
		
		base.OnPlayerTrigger (player, shape);

		if (behaviourMode == BehaviourMode.Wandering || shape != previousShape)
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
		behaviourMode = BehaviourMode.Wandering;

		yield return new WaitForSeconds(Random.Range(2.0f, 4.0f));

		StartCoroutine(WanderCoroutine());
	}

	IEnumerator WanderCoroutine()
	{
		behaviourMode = BehaviourMode.Wandering;

		float startingTime = Time.time;
		float timeToWonder = Random.Range(1.0f, 3.0f);

		RotateAngle(Random.Range(0.0f, 360.0f));

		while (Time.time < startingTime + timeToWonder)
		{
			MoveForward(wanderSpeed);
			yield return null;
		}
		StartCoroutine(StandCoroutine());
	}

	IEnumerator ShelterCoroutine(Vector3 target)
	{
		behaviourMode = BehaviourMode.Wandering;

		float startingTime = Time.time;
		float timeToWonder = startingTime + Random.Range(3.0f, 5.0f);

		RotateToward(target);

		while (Time.time < timeToWonder)
		{
			MoveForward(followSpeed);
			yield return null;
		}
		StartCoroutine(StandCoroutine());
	}

	IEnumerator FollowCoroutine(PlayerBase player)
	{
		behaviourMode = BehaviourMode.Following;

		float distance = Vector3.Distance(transform.position, player.transform.position);

		while (distance > 3.0f && distance < 15.0f)
		{
			RotateToward(player.transform.position);

			MoveForward(followSpeed);

			yield return null;

			distance = Vector3.Distance(transform.position, player.transform.position);
		}

		StartCoroutine(StandCoroutine());
	}

	IEnumerator FleeCoroutine(GameObject target)
	{
		behaviourMode = BehaviourMode.Fleeing;

		float startingTime = Time.time;
		float timeToFlee = startingTime + Random.Range(1.0f, 3.0f);

		RotateToward(target.transform.position);
		RotateAngle(180.0f);

		while (Time.time < timeToFlee)
		{
			MoveForward(runSpeed);

			yield return null;
		}

		StartCoroutine(StandCoroutine());

	}

}
