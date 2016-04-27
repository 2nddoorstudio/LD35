using UnityEngine;
using System.Collections;

namespace SecondDoorStudio.HotF.StateMachines
{
	public class WanderState : State {


		IEnumerator WanderCoroutine()
		{

			//Debug.Log("Wandering");
			SetMode(BehaviourMode.Wandering);

			// Original wander behavior below:
			//		float startingTime = Time.time;
			//		float timeToWonder = Random.Range(1.0f, 3.0f);
			//
			//		RotateAngle(Random.Range(0.0f, 360.0f));
			//
			//		while (Time.time < startingTime + timeToWonder)
			//		{
			//			//MoveForward();
			//			yield return null;
			//		}


			RotateAngle(Random.Range(0f, 360f));
			RaycastHit hit;
			if (Physics.Raycast((transform.position + (transform.forward * 10f) + (Vector3.up *2f)), Vector3.down, out hit, 10f)) {
				nma.SetDestination(hit.point);
				nma.Resume();
			}

			float distance = Vector3.Distance(transform.position, nma.destination);

			while (distance > 1f) {
				yield return new WaitForSeconds(0.1f);
				distance = Vector3.Distance(transform.position, nma.destination);
			}

			StartCoroutine(StandCoroutine());
		}

		/*IEnumerator WanderCoroutine()
		{
			SetMode(BehaviourMode.Wandering);
			
			float startingTime = Time.time;
			float timeToWonder = Random.Range(1.0f, 3.0f);
			
			RotateAngle(Random.Range(0.0f, 360.0f));
			
			while (Time.time < startingTime + timeToWonder)
			{
				MoveForward();
				yield return null;
			}
			StartCoroutine(StandCoroutine());

		}*/
	}

}
