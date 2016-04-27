using UnityEngine;
using System.Collections;

public class EnemyCaster : UnitBase {

	[SerializeField]
	float walkSpeed = 0.1f;
	[SerializeField]
	float trackSpeed = 0.15f;
	[SerializeField]
	float runSpeed = 0.16f;

	[SerializeField]
	float attackRange = 5.0f;
	float castingRange = 25.0f;

	float castTime = 5f;	// Seconds

	GameObject target;

	public GameObject testBall;

	// Use this for initialization
	public override void Start () {
		base.Start();

		StartCoroutine(WanderCoroutine());
	}

	// Update is called once per frame
	public override void Update () 
	{
		base.Update();
	
	}

	private void OnDrawGizmos () {
     	Gizmos.color = Color.red;
     	//Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.

     	Gizmos.DrawWireSphere (testBall.transform.position, 3f);
 	}

	IEnumerator WanderCoroutine()
	{
		behaviourMode = BehaviourMode.Wandering;
		animator.SetBool("IsAttacking", false);
		animator.SetFloat("AnimSpeed", 0.5f);

		float startingTime = Time.time;
		float timeToWonder = Random.Range(3.0f, 5.0f);

		RotateAngle(Random.Range(0.0f, 360.0f));

		while (Time.time < startingTime + timeToWonder)
		{
			//MoveForward(walkSpeed);
			yield return null;
		}
		StartCoroutine(WanderCoroutine());
	}

	IEnumerator FollowCoroutine(UnitBase target)
	{
		behaviourMode = BehaviourMode.Following;
		animator.SetBool("IsAttacking", false);
		animator.SetFloat("AnimSpeed", 1.0f);

		float distance = Vector3.Distance(transform.position, target.transform.position);
		while (distance > castingRange)	{

			RotateToward(target.transform.position);
			distance = Vector3.Distance(transform.position, target.transform.position);
			//Debug.Log(distance);

			MoveForward(trackSpeed);

			yield return null;
		}

		StartCoroutine(CastCoroutine(target));
	}

	IEnumerator CastCoroutine(UnitBase target)
	{
		behaviourMode = BehaviourMode.Casting;
		movementSpeed = 0.0f;
		animator.SetFloat("AnimSpeed", 0.0f);
		animator.SetBool("IsAttacking", true);

		float castingTimeRemaining = castTime;
		Vector3 startLerpLoc;
		Vector3 targetLoc = Vector3.zero;

		testBall.transform.localScale = Vector3.one*.5f;

		while (target != null && castingTimeRemaining > 0) {

			while (castingTimeRemaining > 1.5) {

				targetLoc = target.transform.position;
				testBall.transform.position = targetLoc;

				RotateToward(target.transform.position);
				castingTimeRemaining -= Time.deltaTime;

				yield return null;

			}

			RaycastHit hit;
			Vector3 startRay = target.transform.position + (target.transform.forward * target.GetComponent<NavMeshAgent>().velocity.magnitude) + Vector3.up * 3f;

			if(Physics.Raycast(startRay, Vector3.down, out hit, 150f, Globals.GroundLayerMask)) {
				targetLoc = hit.point;
			}


			startLerpLoc = testBall.transform.position;
			float lerpT = 0f;

			while (castingTimeRemaining > 0) {
				testBall.transform.position = Vector3.Lerp(startLerpLoc, targetLoc, lerpT);
				lerpT += Time.deltaTime / 1.5f;
				RotateToward(target.transform.position);
				castingTimeRemaining -= Time.deltaTime;
				yield return null;
			}

		}

		Collider[] colliders = Physics.OverlapSphere(targetLoc, 3f);
		testBall.transform.localScale = Vector3.one * 6f;
		foreach (Collider collider in colliders) {
			if (collider.gameObject.GetComponent<VillagerControllerNav>() != null) {
				if (collider.gameObject != null)
					Destroy(collider.gameObject);
			}
		}

//		animator.SetBool("IsAttacking", false);

		StartCoroutine(WanderCoroutine());
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

	IEnumerator FleeCoroutine(GameObject target)
	{
		behaviourMode = BehaviourMode.Fleeing;
		movementSpeed = walkSpeed;
		animator.SetBool("IsAttacking", false);
		animator.SetFloat("AnimSpeed", 1.0f);

		RotateToward(target.transform.position);
		RotateAngle(180f);

		float endTime = Time.time + Random.Range(2.0f, 4.0f);

		while (Time.time < endTime)
		{
			MoveForward();

			yield return null;
		}

		StartCoroutine(WanderCoroutine());
	}

	public override void OnSanctuaryTrigger(bool entering, GameObject go)
	{
		//if (entering != inSanctuary && entering)
		if (entering)
		{
			StopAllCoroutines();
			StartCoroutine(FleeCoroutine(go));
		}

		inSanctuary = entering;

	}

	void OnTriggerEnter(Collider other)
	{
		VillagerControllerNav villager = other.GetComponent<VillagerControllerNav>();
		if (villager == null)
			return;

		if (behaviourMode == BehaviourMode.Wandering)
		{
			StopAllCoroutines();
			StartCoroutine(FollowCoroutine(villager as UnitBase));
		}

	}
}
