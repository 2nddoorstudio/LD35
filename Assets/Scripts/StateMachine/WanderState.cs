using UnityEngine;
using System.Collections;

namespace SecondDoorStudio.HotF.StateMachines
{
	public class WanderState : VillagerState {


		[SerializeField]
		float speed = 2.5f;

		[SerializeField]
		float minWalk = 4.0f;
		[SerializeField]
		float maxWalk = 6.0f;

		[SerializeField]
		float minWait = 2.0f;
		[SerializeField]
		float maxWait = 4.0f;

		public override void Enter ()
		{
			base.Enter ();

			currentAction = WalkCoroutine();
		}

		IEnumerator WalkCoroutine()
		{
			transform.RotateAround(transform.position, Vector3.up, Random.Range(0f, 360f));

			animator.SetFloat("AnimSpeed", 0.5f);
			nav.speed = speed;

			float walkTime = Random.Range(minWalk, maxWalk);

			RaycastHit hit;
			if (Physics.Raycast((transform.position + (transform.forward * (walkTime * 4f)) + (Vector3.up *2f)), Vector3.down, out hit, 10f)) {
				nav.SetDestination(hit.point);
				nav.Resume();
			}

			float endTime = Time.time + walkTime;

			while (Time.time < endTime)
			{
				yield return null;
			}

			currentAction = StandCoroutine();
		}

		IEnumerator StandCoroutine()
		{
			animator.SetFloat("AnimSpeed", 0.0f);
			nav.Stop();

			float waitTime = Random.Range(minWait, maxWait);

			yield return new WaitForSeconds(waitTime);

			currentAction = WalkCoroutine();
		}

	}

}
