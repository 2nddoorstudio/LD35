using UnityEngine;
using System.Collections;

namespace SecondDoorStudio.HotF.StateMachines
{
	public class VillagerInitState : VillagerState {
		public override void Enter ()
		{
			base.Enter ();

			currentAction = Init();
		}

		IEnumerator Init ()
		{
			yield return null;

			owner.ChangeState<WanderState>();
		}

	}
	
}
