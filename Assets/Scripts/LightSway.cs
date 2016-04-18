using UnityEngine;
using System.Collections;

public class LightSway : MonoBehaviour {

	[SerializeField]
	Renderer render;

	[SerializeField]
	float offsetX = 0.01f;
	[SerializeField]
	float offsetY = 0.01f;
	[SerializeField]
	float speedX = 0.9f;
	[SerializeField]
	float speedY = 0.9f;

	// Update is called once per frame
	void Update () 
	{
		float x = Mathf.Sin(Time.time * speedX) * offsetX;
		float y = Mathf.Sin(Time.time * speedY) * offsetY;

		Vector3 angle = transform.rotation.eulerAngles;
		angle.x += x;
		angle.y += y;
		transform.rotation = Quaternion.Euler(angle);

	}
}
