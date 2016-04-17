using UnityEngine;
using System.Collections;

public class VillagerController : UnitBase {

	enum Mode
	{
		Wander,
		Follow
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

		switch (shape) 
		{
		case Shapeshift.Human:

			break;
		case Shapeshift.Stag:
			Debug.Log("Start Follow");
			target = player.gameObject;
			StartCoroutine(FollowCoroutine());
			break;
		case Shapeshift.Bear:
			break;
		default:
			break;
		}
	}

	IEnumerator StandCoroutine()
	{
		float startingTime = Time.time;
		float timeToStand = Random.Range(2.0f, 4.0f);

		while (Time.time < startingTime + timeToStand)
		{
			yield return null;
		}

		StartCoroutine(WanderCoroutine());
	}

	IEnumerator WanderCoroutine()
	{
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

	IEnumerator FollowCoroutine()
	{
		StopAllCoroutines();

		float distance = Vector3.Distance(transform.position, target.transform.position);

		while (distance > 3.0f && distance < 10.0f)
		{
			transform.rotation = Quaternion.LookRotation(target.transform.position, Vector3.up);
			transform.Translate(Vector3.forward * followSpeed);
			yield return null;
			distance = Vector3.Distance(transform.position, target.transform.position);
		}

		StartCoroutine(WanderCoroutine());
	}

	public void UpdateFollow()
	{
		
	}

	public void UpdateRun()
	{
		
	}

	public void UpdateAttack()
	{
		
	}
}
