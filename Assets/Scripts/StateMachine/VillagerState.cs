using UnityEngine;
using System.Collections;

namespace SecondDoorStudio.HotF.StateMachines
{
	public class VillagerState : State {

		protected VillagerController owner;
		public NavMeshAgent nav {get {return owner.nav;}}
		public Animator animator {get {return owner.animator;}}
		public GameObject target {get {return owner.target;}}
		public bool isInSanctuary {get {return owner.isInSanctuary;} set {owner.isInSanctuary = value;}}
		public bool isFollowing {get {return owner.isFollowing;} set {owner.isFollowing = value;}}

		protected virtual void Awake () 
		{
			owner = GetComponent<VillagerController>();

		}

	}

}