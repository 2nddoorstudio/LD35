using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*public void MoveForward(float speed)
	{
		transform.Translate(Vector3.forward * speed);
	}
	public void MoveForward()
	{
		MoveForward(movementSpeed);
	}*/

	public void RotateToward(Vector3 target)
	{
		Vector3 vDirection = target - transform.position;
		float angle = Mathf.Sign(Vector3.Dot(vDirection, Vector3.right)) * Vector3.Angle(vDirection, Vector3.forward);
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
	}

	public void RotateAngle(float angle)
	{
		transform.RotateAround(transform.position, Vector3.up, angle);
	}

}
