using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	[SerializeField]
	GameObject target;

	[SerializeField]
	float followSpeed = 0.03f;

	[SerializeField]
	float lead = 3.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(transform.position, target.transform.position + (target.transform.forward * lead), followSpeed);
	}
}
