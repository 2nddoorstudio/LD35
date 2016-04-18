using UnityEngine;
using System.Collections;

public class WaypointController : MonoBehaviour {

	[SerializeField]
	GameObject arrow;

	[SerializeField]
	GameObject player;

	[SerializeField]
	GameObject grove;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 v1 = Camera.main.WorldToViewportPoint(grove.transform.position);
		Vector2 v2 = Camera.main.ScreenToViewportPoint(player.transform.position);

		float angle = Mathf.Atan2(v1.y - v2.y, v1.x - v2.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (new Vector3(0f, -(angle - Camera.main.transform.parent.transform.rotation.eulerAngles.y), 0f));

	}
}
