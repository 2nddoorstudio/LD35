using UnityEngine;
using System.Collections;

public class SanctuaryController : MonoBehaviour {

	[SerializeField]
	Projector projector;			// Projector component for the glowing circle -- define in editor

	// Defined values for fade speeds -- serialize these fields if desired for editor tweaking
	float defaultAlpha = 0.35f;
	float glowFadeInSpeed = 1.5f;
	float glowFadeOutSpeed = 0.5f;	

	int VillagerCount;

	// Use this for initialization
	void Start () 
	{
		projector.material.color = new Color(0,1,1,defaultAlpha);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//if as villager has been added since last frame
		if (VillagerCount < EntityManager.safeVillagers)
			StartCoroutine(GlowUp());	// Begin glow effect
		
		VillagerCount = EntityManager.safeVillagers;
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

	IEnumerator GlowUp() {

		// Cancel any glow coroutines that have already been started
		StopCoroutine(GlowUp());
		StopCoroutine(GlowDown());

		// Current alpha value
		float alpha = projector.material.color.a;

		while (alpha < 1f) {	// 1f is full alpha
			alpha += glowFadeInSpeed * Time.deltaTime;
			projector.material.color = new Color(0,1,1,alpha);
        	yield return new WaitForEndOfFrame();
		}

		StartCoroutine(GlowDown());
		yield break;
	}

	IEnumerator GlowDown() {

		// Current alpha value
		float alpha = projector.material.color.a;

		while (alpha > defaultAlpha) {
			alpha -= glowFadeOutSpeed * Time.deltaTime;
			projector.material.color = new Color(0,1,1,alpha);
        	yield return new WaitForEndOfFrame();
		}

		yield break;
	}

}
