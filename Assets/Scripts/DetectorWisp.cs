using UnityEngine;
using System.Collections;

public class DetectorWisp : MonoBehaviour {

	[SerializeField]
	float movementSpeed;

	[SerializeField]
	PlayerBase player;

	Vector3 target;

	public Vector3 Target {
		get { return target; }
		set { target = value; }
	}

	ParticleSystem particleSystem;

	void Start () {
		particleSystem = GetComponent<ParticleSystem>();
		//target = player.transform.position;
	}
	void Update() {
		transform.position = Vector3.MoveTowards(transform.position, target, movementSpeed * Time.deltaTime);
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			if (other.isTrigger == false) {	// Prevents vanishing against the detection sphere collider, which is just a trigger
				StartCoroutine(FadeOut());
			}
		}
	}

	public void CallFadeOut() {
		StartCoroutine(FadeOut());
	}

	IEnumerator FadeOut() {
		particleSystem.Stop();
		yield return new WaitForSeconds(2f);
	    Destroy(gameObject);
	    yield break;
	}

}
