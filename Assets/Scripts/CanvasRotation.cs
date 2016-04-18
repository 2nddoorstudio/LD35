using UnityEngine;
using System.Collections;

public class CanvasRotation : MonoBehaviour {

	Vector3 rotation;

	bool isRotating = false;

	//float firstAngle = -90f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
//		if (Input.GetKeyDown(KeyCode.T))
//		{
//			RotateUI(gameObject, firstAngle, 0.5f);
//
//		}
//
//		if (Input.GetKeyDown(KeyCode.Y))
//		{
//			RotateUI(gameObject, 20f, 0.5f);
//
//		}
	}

	public void RotateUI(GameObject go, float angle, float duration)
	{
		if (isRotating )
		{
			StopAllCoroutines();
		}
		StartCoroutine(RotateUICoroutine(gameObject, angle, duration));

	}

	IEnumerator RotateUICoroutine(GameObject go, float angle, float duration)
	{
		isRotating = true;

		float startTime = Time.time;
		float endTime = startTime + duration;

		rotation = go.transform.rotation.eulerAngles;
		float startAngle = rotation.z;
		float newAngle = startAngle;
		float t = 0.0f;

		while(t < 1f)
		{
			Debug.Log(newAngle);
			t = Mathf.InverseLerp(startTime, endTime, Time.time);
			newAngle = Mathf.LerpAngle(startAngle, angle, t);
			rotation.z = newAngle;
			transform.rotation = Quaternion.Euler(rotation);
			yield return null;
		}

		isRotating = false;
	}
}
