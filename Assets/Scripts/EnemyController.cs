using UnityEngine;
using System.Collections;

public class EnemyController : UnitBase {

	[SerializeField]
	float walkSpeed = 0.1f;
	[SerializeField]
	float trackSpeed = 0.15f;

	[SerializeField]
	float attackRange = 3.0f;

	GameObject target;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine(WanderCoroutine());

	}
	
	// Update is called once per frame
	void Update () 
	{
		base.Update();
	
	}

	IEnumerator WanderCoroutine()
	{
		behaviourMode = BehaviourMode.Wandering;

		float startingTime = Time.time;
		float timeToWonder = Random.Range(3.0f, 5.0f);

		RotateAngle(Random.Range(0.0f, 360.0f));

		while (Time.time < startingTime + timeToWonder)
		{
			MoveForward(walkSpeed);
			yield return null;
		}
		StartCoroutine(WanderCoroutine());
	}

	IEnumerator FollowCoroutine(UnitBase target)
	{
		behaviourMode = BehaviourMode.Following;

		RotateToward(target.transform.position);

		float distance;
		do
		{
			distance = Vector3.Distance(transform.position, target.transform.position);

			MoveForward(trackSpeed);

			yield return null;
		}
		while(distance > attackRange);

		StartCoroutine(AttackCoroutine(target));
	}

	IEnumerator AttackCoroutine(UnitBase target)
	{
		behaviourMode = BehaviourMode.Attacking;

		while(target.GetNormalizedHealth() > 0.0f)
		{
			//TODO: Attack
			yield return null;
		}

		StartCoroutine(WanderCoroutine());
	}

	void OnTriggerEnter(Collider other)
	{
		VillagerController villager = other.GetComponent<VillagerController>();
		if (villager == null)
			return;

		if (behaviourMode == BehaviourMode.Wandering)
		{
			StartCoroutine(FollowCoroutine(villager as UnitBase));
		}
			
	}
}
