using UnityEngine;
using System.Collections;

namespace SecondDoorStudio.HotF.StateMachines
{
	public class VillagerController : StateMachine {

		public NavMeshAgent nav;

		void Start () 
		{
			ChangeState<VillagerInitState>();
		}

	}
	
}
