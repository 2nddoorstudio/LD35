using UnityEngine;
using System.Collections;

namespace SecondDoorStudio.HotF.StateMachines
{
	public class VillagerFollow : VillagerState {

		[SerializeField]
		float speed = 5f;

		[SerializeField]
		float maxFollowDistance = 15.0f;
		[SerializeField]
		float minFollowDistance = 2.5f;

		public override void Enter ()
		{
			base.Enter ();

			currentAction = FollowCoroutine();
		}

		IEnumerator FollowCoroutine() {

			nav.speed = speed;

			float distance = Vector3.Distance(transform.position, target.transform.position);
			nav.SetDestination(target.transform.position);	// Keep updating the NavMeshAgent's destination (Vector3)
			nav.Resume();

			//		while (distance > 3.0f && distance < 15.0f)	{
			while (distance < maxFollowDistance) 
			{
				distance = Vector3.Distance(transform.position, target.transform.position);

				if (distance < minFollowDistance) 
				{
					nav.Stop();
				} 
				else 
				{
				  	nav.SetDestination(target.transform.position);	// Keep updating the NavMeshAgent's destination (Vector3)
				}

				yield return new WaitForSeconds(0.1f);
				//			yield return null;

			}
		}
	}
	
}
