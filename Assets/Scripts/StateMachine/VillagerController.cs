using UnityEngine;
using System.Collections;

namespace SecondDoorStudio.HotF.StateMachines
{
	public class VillagerController : StateMachine {

		public NavMeshAgent nav;
		public Animator animator;

		public GameObject target;

		bool inSanctuary = false;

		void Start () 
		{
			ChangeState<VillagerInitState>();
		}

		public void OnPlayerTrigger (PlayerBase player, Shapeshift shape)
		{
			target = player.gameObject;

			ChangeState<VillagerFollow>();

			//player.
			/*if (behaviourMode == BehaviourMode.Wandering || behaviourMode == BehaviourMode.Standing || behaviourMode == BehaviourMode.Following || shape != previousShape)
			{
				switch (shape) 
				{
				case Shapeshift.Human:
					if (inSanctuary) break;
					StopAllCoroutines();
					StartCoroutine(FollowCoroutine(player));
					break;
				case Shapeshift.Stag:
					if (inSanctuary) break;
					StopAllCoroutines();
					StartCoroutine(FollowCoroutine(player));
					break;
				case Shapeshift.Bear:
					StopAllCoroutines();
					StartCoroutine(FleeCoroutine(player.gameObject));
					break;
				default:
					break;
				}

			}

			previousShape = shape;
			*/
		}
		//	public override void OnPlayerExit (PlayerBase player, Shapeshift shape) {
		//		following = false;
		//		target = null;
		//	}

		public void OnSanctuaryTrigger(bool safe, GameObject go)
		{
			if (safe != inSanctuary && safe)
			{
				ChangeState<VillagerSanctuary>();
				/*StopAllCoroutines();
				StartCoroutine(ShelterCoroutine(go.transform.position));*/
				//GameManager.safeVillagers += 1;
			}

			//		Debug.Log("On Sanctuary Trigger");
			inSanctuary = safe;

		}

		public void OnBear()
		{
			
			//ChangeState<
		}
	}
	
}
