using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class VillagerController : UnitBase {


	[SerializeField]
	float wanderSpeed = 0.05f;
	[SerializeField]
	float runSpeed = 0.15f;
	[SerializeField]
	float followSpeed = 0.1f;

	Dictionary<BehaviourMode, float> speeds;

	[SerializeField]
	float chanceToWander = 0.1f;
	[SerializeField]
	float chanceToStopWandering = 0.9f;

	Shapeshift shape;
	Shapeshift previousShape;

	bool inSanctuary = false;

	// Use this for initialization
	public override void Start () {
		base.Start();

		speeds = new Dictionary<BehaviourMode, float>();

		speeds.Add(BehaviourMode.Standing, 0.0f);
		speeds.Add(BehaviourMode.Wandering, wanderSpeed);
		speeds.Add(BehaviourMode.Following, followSpeed);
		speeds.Add(BehaviourMode.Fleeing, runSpeed);
		speeds.Add(BehaviourMode.Attacking, 0.0f);


		StartCoroutine(StandCoroutine());
	}
	
	// Update is called once per frame
	void Update () {
		base.Update();
	}

	public override void OnPlayerTrigger (PlayerBase player, Shapeshift shape)
	{
		
		base.OnPlayerTrigger (player, shape);

		if (behaviourMode == BehaviourMode.Wandering || behaviourMode == BehaviourMode.Standing || shape != previousShape)
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
			GameManager.safeVillagers += 1;
		}

		inSanctuary = safe;

		//if (safe)

	}

	void SetMode(BehaviourMode mode)
	{
		behaviourMode = mode;

		if(speeds == null)
		{
			Debug.Log("speed is null");
			return;
		}
		else
			movementSpeed = speeds[mode];


		//animationSpeed = Mathf.InverseLerp(wanderSpeed, runSpeed, movementSpeed);
		//animationSpeed += 0.4f;
		if (mode == BehaviourMode.Standing) animationSpeed = 0.0f;
		if (mode == BehaviourMode.Attacking) animationSpeed = 0.0f;
		if (mode == BehaviourMode.Wandering) animationSpeed = 0.5f;
		if (mode == BehaviourMode.Fleeing) animationSpeed = 1.0f;
		if (mode == BehaviourMode.Following) animationSpeed = 0.7f;
		//Debug.Log(animationSpeed);
		animator.SetFloat("AnimSpeed", animationSpeed);
	}

	IEnumerator StandCoroutine()
	{
		/*behaviourMode = BehaviourMode.Standing;
		movementSpeed = 0.0f;
		animator.SetFloat("AnimSpeed", 0.0f);*/
		SetMode(BehaviourMode.Standing);

		yield return new WaitForSeconds(Random.Range(2.0f, 4.0f));

		StartCoroutine(WanderCoroutine());
	}

	IEnumerator WanderCoroutine()
	{
		/*behaviourMode = BehaviourMode.Wandering;
		movementSpeed = wanderSpeed;
		animator.SetFloat("AnimSpeed", 0.5f);*/
		SetMode(BehaviourMode.Wandering);

		float startingTime = Time.time;
		float timeToWonder = Random.Range(1.0f, 3.0f);

		RotateAngle(Random.Range(0.0f, 360.0f));

		while (Time.time < startingTime + timeToWonder)
		{
			MoveForward();
			yield return null;
		}
		StartCoroutine(StandCoroutine());
	}

	IEnumerator ShelterCoroutine(Vector3 target)
	{
		/*behaviourMode = BehaviourMode.Wandering;
		movementSpeed = followSpeed;
		animator.SetFloat("AnimSpeed", 0.5f);*/
		SetMode(BehaviourMode.Following);

		float startingTime = Time.time;
		float timeToWonder = startingTime + Random.Range(3.0f, 5.0f);

		RotateToward(target);

		while (Time.time < timeToWonder)
		{
			MoveForward();
			yield return null;
		}
		StartCoroutine(StandCoroutine());
	}

	IEnumerator FollowCoroutine(PlayerBase player)
	{
		/*behaviourMode = BehaviourMode.Following;
		movementSpeed = followSpeed;
		animator.SetFloat("AnimSpeed", 0.5f);*/
		SetMode(BehaviourMode.Following);

		float distance = Vector3.Distance(transform.position, player.transform.position);

		while (distance > 3.0f && distance < 15.0f)
		{
			RotateToward(player.transform.position);

			MoveForward();

			yield return null;

			distance = Vector3.Distance(transform.position, player.transform.position);
		}

		StartCoroutine(StandCoroutine());
	}

	IEnumerator FleeCoroutine(GameObject target)
	{
		/*behaviourMode = BehaviourMode.Fleeing;
		movementSpeed = runSpeed;
		animator.SetFloat("AnimSpeed", 1.0f);*/
		SetMode(BehaviourMode.Fleeing);

		float startingTime = Time.time;
		float timeToFlee = startingTime + Random.Range(1.0f, 3.0f);

		RotateToward(target.transform.position);
		RotateAngle(180.0f);

		while (Time.time < timeToFlee)
		{
			MoveForward();

			yield return null;
		}

		StartCoroutine(StandCoroutine());

	}

}
