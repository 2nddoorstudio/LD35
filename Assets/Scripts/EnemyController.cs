﻿using UnityEngine;
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
	public override void Start () {
		base.Start();

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
		animator.SetFloat("AnimSpeed", 0.5f);

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
		animator.SetFloat("AnimSpeed", 1.0f);


		float distance = Vector3.Distance(transform.position, target.transform.position);
		while(distance > attackRange)
		{

			RotateToward(target.transform.position);
			distance = Vector3.Distance(transform.position, target.transform.position);
			//Debug.Log(distance);

			MoveForward(trackSpeed);

			yield return null;
		}


		StartCoroutine(AttackCoroutine(target));
	}

	IEnumerator AttackCoroutine(UnitBase target)
	{
		behaviourMode = BehaviourMode.Attacking;
		movementSpeed = 0.0f;
		animator.SetFloat("AnimSpeed", 0.0f);
		animator.SetBool("IsAttacking", true);
		//Debug.Log(target.currentHealth);
		while(target != null && target.currentHealth > 0.1f)
		{
			//Debug.Log("attacking");
			target.TakeDamage(0.1f, this as UnitBase);
			//TODO: Attack
			RotateToward(target.transform.position);

			yield return null;
		}

		animator.SetBool("IsAttacking", false);

		StartCoroutine(WanderCoroutine());
	}

	void OnTriggerEnter(Collider other)
	{
		VillagerController villager = other.GetComponent<VillagerController>();
		if (villager == null)
			return;

		if (behaviourMode == BehaviourMode.Wandering)
		{
			StopAllCoroutines();
			StartCoroutine(FollowCoroutine(villager as UnitBase));
		}
			
	}
}
