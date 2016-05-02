using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	[SerializeField]
	GameObject arrow;

	bool shotCharging = false;
	float shotTimer;
	float cooldownTimer = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("Fire1")) {
			shotCharging = true;
		}

		if (shotCharging) {
			if (shotTimer < 1.5f)
				shotTimer += Time.deltaTime;
			Debug.Log(shotTimer);
		}

		if (cooldownTimer > 0) {
			cooldownTimer -= Time.deltaTime;
		}

		if (Input.GetButtonUp("Fire1")) {
			if (cooldownTimer <= 0) {
				Debug.Log("Bang! " + shotTimer);

				//TODO: Adjust arrow charge time to feel more satisfying

				// Version 1: Arrow has more strength (flies further/straighter) by charging
				GameObject arrowPrefab = (GameObject) Instantiate(arrow, transform.position + (transform.up) + (transform.forward*2), transform.rotation) as GameObject;
				arrowPrefab.GetComponent<Rigidbody>().AddForce(transform.forward * (150f * shotTimer), ForceMode.Impulse);
				arrowPrefab.GetComponent<Rigidbody>().AddForce(transform.up * (15f * shotTimer), ForceMode.Impulse);

				// Version 2: Arrow is more accurate (narrows a target cone to a fixed point) by charging
	//			Quaternion adjustedAngle = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y+Random.Range(-10f+shotTimer*5f,10f-shotTimer*5), transform.rotation.eulerAngles.z+Random.Range(-10f+shotTimer*5f,10f-shotTimer*5f));
	//			GameObject arrowPrefab = (GameObject) Instantiate(arrow, transform.position + (transform.up) + (transform.forward*2), adjustedAngle) as GameObject;
	//			arrowPrefab.GetComponent<Rigidbody>().AddForce(arrowPrefab.transform.forward * (200f), ForceMode.Impulse);
	//			arrowPrefab.GetComponent<Rigidbody>().AddForce(transform.up * (20f), ForceMode.Impulse);

				shotTimer = 0;
				shotCharging = false;
				cooldownTimer = 0.5f;
			}
		}
	
	}
}
