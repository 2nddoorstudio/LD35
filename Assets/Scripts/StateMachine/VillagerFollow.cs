using UnityEngine;
using System.Collections;

namespace SecondDoorStudio.HotF.StateMachines
{
	public class VillagerFollow : VillagerState {

		[SerializeField]
		float speed = 5f;

		[SerializeField]
		float maxFollowDistance = 15.0f;

		public override void Enter ()
		{
			base.Enter ();

			isFollowing = true;

			currentAction = FollowCoroutine();
		}

		public override void Exit ()
		{
			base.Exit ();

			isFollowing = false;
		}

		IEnumerator FollowCoroutine() 
		{
			nav.speed = speed;

			float distance = Vector3.Distance(transform.position, target.transform.position);
			nav.SetDestination(target.transform.position);	// Keep updating the NavMeshAgent's destination (Vector3)
			nav.Resume();

			while (distance < maxFollowDistance) 
			{
				distance = Vector3.Distance(transform.position, target.transform.position);

				if (distance < nav.stoppingDistance) 
				{
					animator.SetFloat("AnimSpeed", 0.0f);
					nav.Stop();
				} 
				else 
				{
					animator.SetFloat("AnimSpeed", 0.5f);
				  	nav.SetDestination(target.transform.position);	// Keep updating the NavMeshAgent's destination (Vector3)
					nav.Resume();
				}

				yield return new WaitForSeconds(0.1f);
				//			yield return null;

			}

			owner.ChangeState<WanderState>();
		}

	}
	
}
