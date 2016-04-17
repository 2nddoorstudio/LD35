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
			//target = player.gameObject;
			StopAllCoroutines();
			StartCoroutine(FollowCoroutine(player));
			break;
		case Shapeshift.Bear:
			break;
		default:
			break;
		}
	}

	IEnumerator StandCoroutine()
	{
		yield return new WaitForSeconds(Random.Range(2.0f, 4.0f));

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

	IEnumerator FollowCoroutine(PlayerBase player)
	{
		float distance = Vector3.Distance(transform.position, player.transform.position);

		while (distance > 1.0f && distance < 15.0f)//(true)//
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

	public void UpdateRun()
	{
		
	}

	public void UpdateAttack()
	{
		
	}
}
