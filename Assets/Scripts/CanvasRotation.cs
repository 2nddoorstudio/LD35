using UnityEngine;
using System.Collections;

public class CanvasRotation : MonoBehaviour {

	Vector3 rotation;

	bool isRotating = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void RotateUI(float angle, float duration)
	{
		if (isRotating)
		{
			StopAllCoroutines();
		}
		StartCoroutine(RotateUICoroutine(angle, duration));

	}

	public void RotateUI(float angle)
	{
		rotation = transform.rotation.eulerAngles;
		rotation.z = angle;
		transform.rotation = Quaternion.Euler(rotation);

	}

	IEnumerator RotateUICoroutine(float angle, float duration)
	{
		isRotating = true;

		float startTime = Time.time;
		float endTime = startTime + duration;

		rotation = transform.rotation.eulerAngles;
		float startAngle = rotation.z;
		float newAngle = startAngle;
		float t = 0.0f;

		while(t < 1f)
		{
			//Debug.Log(newAngle);
			t = Mathf.InverseLerp(startTime, endTime, Time.time);
			newAngle = Mathf.LerpAngle(startAngle, angle, t);
			rotation.z = newAngle;
			transform.rotation = Quaternion.Euler(rotation);
			yield return null;
		}

		isRotating = false;
	}
}
