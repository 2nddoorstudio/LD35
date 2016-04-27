using UnityEngine;
using System.Collections;

namespace SecondDoorStudio.HotF.StateMachines
{
	public class VillagerSanctuary : VillagerState {

		public override void Enter ()
		{
			base.Enter ();
			currentAction = ShelterCoroutine();
		}

		IEnumerator ShelterCoroutine()
		{
			animator.SetFloat("AnimSpeed", 0.5f);
			
			nav.SetDestination(Vector3.zero);
			float distance = Vector3.Distance(transform.position, Vector3.zero);
			
			while (distance > 1f) {
				yield return new WaitForSeconds(0.1f);
			}

			owner.ChangeState<WanderState>();
		}
	}
	
}
