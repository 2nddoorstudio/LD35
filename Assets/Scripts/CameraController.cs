using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	[SerializeField]
	GameObject target;

	[SerializeField]
	float followSpeed = 0.03f;

	[SerializeField]
	float lead = 3.0f;

	[SerializeField]
	float defaultAngle = 45.0f;

	[SerializeField]
	float rotationSpeed = 30f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(transform.position, target.transform.position + (target.transform.forward * lead), followSpeed);

		// Rotate camera around Up axis, centered on target, with keys Q and E, for left and right, respectively
		if (Input.GetKey(KeyCode.Q)) {
			transform.RotateAround(target.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);	
		} else if (Input.GetKey(KeyCode.E)) {
			transform.RotateAround(target.transform.position, Vector3.up, -rotationSpeed * Time.deltaTime);	
		}

	}
}
