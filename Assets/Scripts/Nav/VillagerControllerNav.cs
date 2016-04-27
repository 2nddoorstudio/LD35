using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class VillagerControllerNav : UnitBase {

	[SerializeField]
	float wanderSpeed = 0.05f;
	[SerializeField]
	float runSpeed = 0.15f;
	[SerializeField]
	float followSpeed = 0.1f;

	float nmaWanderSpeed = 2.5f;
	float nmaRunSpeed = 10f;
	float nmaFollowSpeed = 4.35f;

	Dictionary<BehaviourMode, float> speeds;

	[SerializeField]
	float chanceToWander = 0.1f;
	[SerializeField]
	float chanceToStopWandering = 0.9f;

	bool following = false;

	Shapeshift shape;
	Shapeshift previousShape;

	NavMeshAgent nma;
	Transform target;

	public void Awake() {
		nma = GetComponent<NavMeshAgent>();
	}
		
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
	public override void Update () 
	{
		base.Update();
	}

	public override void OnPlayerTrigger (PlayerBase player, Shapeshift shape)
	{
		base.OnPlayerTrigger (player, shape);

		if (behaviourMode == BehaviourMode.Wandering || behaviourMode == BehaviourMode.Standing || behaviourMode == BehaviourMode.Following || shape != previousShape)
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
//	public override void OnPlayerExit (PlayerBase player, Shapeshift shape) {
//		following = false;
//		target = null;
//	}

	public override void OnSanctuaryTrigger(bool safe, GameObject go)
	{
		if (safe != inSanctuary && safe)
		{
			StopAllCoroutines();
			StartCoroutine(ShelterCoroutine(go.transform.position));
			//GameManager.safeVillagers += 1;
		}

//		Debug.Log("On Sanctuary Trigger");
		inSanctuary = safe;

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
//		if (mode == BehaviourMode.Attacking) animationSpeed = 0.0f;
//		if (mode == BehaviourMode.Wandering) animationSpeed = 0.5f;
//		if (mode == BehaviourMode.Fleeing) animationSpeed = 1.0f;
//		if (mode == BehaviourMode.Following) animationSpeed = 0.7f;
		if (mode == BehaviourMode.Wandering) animationSpeed = nmaWanderSpeed;
		if (mode == BehaviourMode.Fleeing) animationSpeed = nmaRunSpeed;
		if (mode == BehaviourMode.Following) animationSpeed = nmaFollowSpeed;
		//Debug.Log(animationSpeed);
		animator.SetFloat("AnimSpeed", animationSpeed);
	}

	IEnumerator StandCoroutine()
	{
		/*behaviourMode = BehaviourMode.Standing;
		movementSpeed = 0.0f;
		animator.SetFloat("AnimSpeed", 0.0f);*/

		nma.Stop();

		SetMode(BehaviourMode.Standing);
		animator.SetFloat("AnimSpeed",0f);

		yield return new WaitForSeconds(Random.Range(2.0f, 4.0f));

		StartCoroutine(WanderCoroutine());
	}

	IEnumerator WanderCoroutine()
	{

		//Debug.Log("Wandering");
		SetMode(BehaviourMode.Wandering);
		nma.speed = nmaWanderSpeed;

		// Original wander behavior below:
//		float startingTime = Time.time;
//		float timeToWonder = Random.Range(1.0f, 3.0f);
//
//		RotateAngle(Random.Range(0.0f, 360.0f));
//
//		while (Time.time < startingTime + timeToWonder)
//		{
//			//MoveForward();
//			yield return null;
//		}

		RotateAngle(Random.Range(0f, 360f));
		RaycastHit hit;
		if (Physics.Raycast((transform.position + (transform.forward * (nmaWanderSpeed * 2f)) + (Vector3.up *2f)), Vector3.down, out hit, 10f)) {
			nma.SetDestination(hit.point);
			nma.Resume();
		}

		float distance = Vector3.Distance(transform.position, nma.destination);

		while (distance > nma.stoppingDistance) {
			distance = Vector3.Distance(transform.position, nma.destination);
			yield return new WaitForSeconds(0.1f);
		}

		StartCoroutine(StandCoroutine());
	}

	IEnumerator ShelterCoroutine(Vector3 target)
	{
		/*behaviourMode = BehaviourMode.Wandering;
		movementSpeed = followSpeed;
		animator.SetFloat("AnimSpeed", 0.5f);*/

		SetMode(BehaviourMode.Following);

//		float startingTime = Time.time;
//		float timeToWonder = startingTime + Random.Range(3.0f, 5.0f);
//
//		RotateToward(target);

//		while (Time.time < timeToWonder)
//		{
//			MoveForward();
//			yield return null;
//		}

		nma.SetDestination(new Vector3(Random.Range(-4f, 4f), Random.Range(-4f, 4f), Random.Range(-4f,4f)));
		float distance = Vector3.Distance(transform.position, Vector3.zero);

		while (distance > nma.stoppingDistance) {
			distance = Vector3.Distance(transform.position, nma.destination);
			yield return new WaitForSeconds(0.1f);
		}

		StartCoroutine(StandCoroutine());
	}

	IEnumerator FollowCoroutine(PlayerBase player) {

		SetMode(BehaviourMode.Following);
		nma.speed = nmaFollowSpeed;

		float distance = Vector3.Distance(transform.position, player.transform.position);
		nma.SetDestination(player.transform.position);	// Keep updating the NavMeshAgent's destination (Vector3)
		nma.Resume();

//		while (distance > 3.0f && distance < 15.0f)	{
		while (distance < 15f) {

			distance = Vector3.Distance(transform.position, player.transform.position);

			if (distance < nma.stoppingDistance) {
				nma.Stop();
				animator.SetFloat("AnimSpeed",0.0f);
			} else {
				nma.SetDestination(player.transform.position);	// Keep updating the NavMeshAgent's destination (Vector3)
			}

			// Original movement script
//			RotateToward(player.transform.position);
//			MoveForward();
//			yield return null;

			yield return new WaitForSeconds(0.1f);
//			yield return null;

		}

		StartCoroutine(StandCoroutine());

	}

	IEnumerator FleeCoroutine(GameObject target)
	{

		SetMode(BehaviourMode.Fleeing);
		nma.speed = nmaRunSpeed;

		// Original, time-based flee system
//		float startingTime = Time.time;
//		float timeToFlee = startingTime + Random.Range(1.0f, 3.0f);

		RotateToward(target.transform.position);
//		RotateAngle(180.0f);
		RotateAngle(180f + Random.Range(-15f, 15f));	// Adding a bit of randomness?  Swap with above if undesired

		RaycastHit hit;
//		Debug.DrawRay((transform.position + (transform.forward * 15f) + (Vector3.up * 5f)), Vector3.down * 2f, Color.green, 10f);
		if (Physics.Raycast((transform.position + (transform.forward * ((nmaRunSpeed * 2f) + Random.Range(-5f,5f))) + (Vector3.up * 5f)), Vector3.down, out hit, 10f)) {
			nma.SetDestination(hit.point);
			nma.Resume();
		}

		float distance = Vector3.Distance(transform.position, nma.destination);

		while (distance > nma.stoppingDistance) {
			distance = Vector3.Distance(transform.position, nma.destination);
			yield return new WaitForSeconds(0.1f);
		}

//		while (Time.time < timeToFlee)
//		{
//			MoveForward();
//
//			yield return null;
//		}

		StartCoroutine(StandCoroutine());

	}

}
