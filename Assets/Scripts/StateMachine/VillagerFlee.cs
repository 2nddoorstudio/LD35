using UnityEngine;
using System.Collections;

namespace SecondDoorStudio.HotF.StateMachines
{
	public class VillagerFlee : VillagerState {

		[SerializeField]
		float speed = 10.0f;

		public override void Enter ()
		{
			base.Enter ();
			currentAction = FleeCoroutine();
		}

		IEnumerator FleeCoroutine()
		{


			animator.SetFloat("AnimSpeed", 1.0f);
			nav.speed = speed;

			// Original, time-based flee system
			//		float startingTime = Time.time;
			//		float timeToFlee = startingTime + Random.Range(1.0f, 3.0f);

			RotateToward(target.transform.position);
			//		RotateAngle(180.0f);
			RotateAngle(180f + Random.Range(-15f, 15f));	// Adding a bit of randomness?  Swap with above if undesired

			RaycastHit hit;
			//		Debug.DrawRay((transform.position + (transform.forward * 15f) + (Vector3.up * 5f)), Vector3.down * 2f, Color.green, 10f);
			if (Physics.Raycast((transform.position + (transform.forward * ((speed * 2f) + Random.Range(-5f,5f))) + (Vector3.up * 5f)), Vector3.down, out hit, 10f)) {
				nav.SetDestination(hit.point);
				nav.Resume();
			}

			float distance = Vector3.Distance(transform.position, nav.destination);

			while (distance > 1f) {
				distance = Vector3.Distance(transform.position, nav.destination);
				yield return new WaitForSeconds(0.1f);
			}

			owner.ChangeState<WanderState>();
		}

		public void RotateToward(Vector3 target)
		{
			Vector3 vDirection = target - transform.position;
			float angle = Mathf.Sign(Vector3.Dot(vDirection, Vector3.right)) * Vector3.Angle(vDirection, Vector3.forward);
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
		}

		public void RotateAngle(float angle)
		{
			transform.RotateAround(transform.position, Vector3.up, angle);
		}
	}

}
