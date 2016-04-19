using UnityEngine;
using System.Collections;

public class ParticleSmoke : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine("AutoDestroy");
	}

	IEnumerator AutoDestroy () {
		yield return new WaitForSeconds(2);
		Destroy(this.gameObject);
	}
}
