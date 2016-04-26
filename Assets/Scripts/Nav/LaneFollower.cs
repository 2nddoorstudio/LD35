using UnityEngine;
using System.Collections;

[RequireComponent (typeof (NavMeshAgent))]
public class LaneFollower : MonoBehaviour {

	NavMeshAgent nma;

	[SerializeField] Lane lane;
	[SerializeField] bool reverse = false;

	int currentIndex;

	public bool Reverse {
		get { return reverse; }
		set { reverse = value; }
	}

	void Start () {

		nma = GetComponent<NavMeshAgent>();

		if (reverse) {
			currentIndex = lane.Waypoints.Length - 1;
		} else {
			currentIndex = 0;
		}

		transform.position = lane.Waypoints[currentIndex].transform.position;

//		nma.SetDestination(lane.Waypoints[NextWaypoint()].transform.position);
//		AssignNextWaypoint();

	}
	
	void Update () {

	}

	public void AssignNextWaypoint() {

		int previousIndex = currentIndex;
		int nextWaypoint = NextWaypoint();

		Debug.Log(nextWaypoint);

		if (previousIndex == currentIndex) {
			nma.Stop();
			Debug.Log("Reached destination!");
		} else {
			nma.SetDestination(lane.Waypoints[nextWaypoint].transform.position);
		}

	}

	int NextWaypoint () {
		
		if (reverse) {
			currentIndex--;
			if (currentIndex < 0) {
				currentIndex = 0;
			}
		} else {
			currentIndex++;
			if (currentIndex > lane.Waypoints.Length-1) {
				currentIndex = lane.Waypoints.Length-1;
			}
		}

		return currentIndex;

	}

}
