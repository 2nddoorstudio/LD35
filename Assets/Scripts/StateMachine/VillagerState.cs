using UnityEngine;
using System.Collections;

namespace SecondDoorStudio.HotF.StateMachines
{
	public class VillagerState : State {

		protected VillagerController owner;
		public NavMeshAgent nav {get {return owner.nav;}}
		public Animator animator {get {return owner.animator;}}
		public GameObject target {get {return owner.target;}}

		protected virtual void Awake () 
		{
			owner = GetComponent<VillagerController>();

		}

	}

}