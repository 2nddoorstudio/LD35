using UnityEngine;
using System.Collections;

namespace SecondDoorStudio.HotF.StateMachines
{
	public class VillagerSanctuary : VillagerState {

		[SerializeField]
		float walkDuration = 2.0f;

		public override void Enter ()
		{
			base.Enter ();
			currentAction = ShelterCoroutine();
		}

		IEnumerator ShelterCoroutine()
		{
			animator.SetFloat("AnimSpeed", 0.5f);
			
			nav.SetDestination(target.transform.position);

			yield return new WaitForSeconds(walkDuration);

			nav.Stop();
			animator.SetFloat("AnimSpeed", 0.0f);

			owner.ChangeState<WanderState>();
		}
	}
	
}
