using UnityEngine;
using System.Collections;

public class SanctuaryController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		//Debug.Log("in");
		UnitBase unit = other.gameObject.GetComponent<UnitBase>();
		if (unit == null)
			return;

		unit.OnSanctuaryTrigger(true, gameObject);
	}

	void OnTriggerExit(Collider other)
	{
		UnitBase unit = other.gameObject.GetComponent<UnitBase>();
		if (unit == null)
			return;

		unit.OnSanctuaryTrigger(false, gameObject);
	}
}
