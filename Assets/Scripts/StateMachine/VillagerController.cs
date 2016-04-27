using UnityEngine;
using System.Collections;

namespace SecondDoorStudio.HotF.StateMachines
{
	public class VillagerController : StateMachine {

		public NavMeshAgent nav;
		public Animator animator;

		[HideInInspector]
		public GameObject target;

		public bool isInSanctuary = false;
		public bool isFollowing = false;

		void Start () 
		{
			ChangeState<VillagerInitState>();
		}

		public void OnTriggerEnter(Collider other)
		{
			//Enter player radius
			PlayerBase player = other.GetComponent<PlayerBase>();
			if (player != null)
			{
				if (!isInSanctuary)
				{
					player.transformEvent += OnTransformEvent;
					
					target = player.gameObject;
					
					ChangeState<VillagerFollow>();
					
				}
				
			}

			//Enter Sanctuary
			SanctuaryController sanctuary = other.GetComponent<SanctuaryController>();
			if (sanctuary != null)
			{
				isInSanctuary = true;

				target = sanctuary.gameObject;

				ChangeState<VillagerSanctuary>();
			}
		}

		public void OnTriggerExit(Collider other)
		{
			//Exit player radius
			PlayerBase player = other.GetComponent<PlayerBase>();
			if (player != null)
			{
				player.transformEvent -= OnTransformEvent;
			}

			//Exit Sanctuary
			SanctuaryController sanctuary = other.GetComponent<SanctuaryController>();
			if (sanctuary != null)
			{
				isInSanctuary = false;

				target = null;

				ChangeState<WanderState>();
			}
		}

		public void OnTransformEvent(object sender, InfoEventArgs<Shapeshift> e)
		{
			PlayerBase player = sender as PlayerBase;

			switch (e.info) 
			{
			case Shapeshift.Human:
				break;

			case Shapeshift.Stag:
				break;

			case Shapeshift.Bear:
				Debug.Log("Run from bear");
				target = player.gameObject;
				ChangeState<VillagerFlee>();
				break;

			default:
				break;
			}

		}
	}
	
}
