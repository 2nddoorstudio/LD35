using UnityEngine;
using System.Collections;

namespace SecondDoorStudio.HotF.StateMachines
{
	public class UnitState : State {

		protected VillagerController owner;
		public NavMeshAgent nav {get {return owner.nav;}}

		protected virtual void Awake () 
		{
			owner = GetComponent<VillagerController>();

		}

	}

}