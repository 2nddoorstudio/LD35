using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	[SerializeField]
	GameObject arrow;

	bool shotCharging = false;
	float shotTimer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("Fire1")) {
			shotCharging = true;
		}

		if (shotCharging) {
			if (shotTimer < 2)
				shotTimer += Time.deltaTime;
			Debug.Log(shotTimer);
		}

		if (Input.GetButtonUp("Fire1")) {
			Debug.Log("Bang! " + shotTimer);
			GameObject arrowPrefab = (GameObject) Instantiate(arrow, transform.position + (transform.up) + (transform.forward*2), transform.rotation) as GameObject;
			arrowPrefab.GetComponent<Rigidbody>().AddForce(transform.forward * (100f * shotTimer), ForceMode.Impulse);
			arrowPrefab.GetComponent<Rigidbody>().AddForce(transform.up * (10f * shotTimer), ForceMode.Impulse);
			shotTimer = 0;
			shotCharging = false;
		}
	
	}
}
