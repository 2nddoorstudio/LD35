using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpellIcon : MonoBehaviour {

	[SerializeField]
	Image cooldown;

	public bool isCoolingDown = false;
	float cooldownTime;

	void Start () {
	}

	void Update() {

		if (isCoolingDown) {
			cooldown.fillAmount -= 1.0f / cooldownTime * Time.deltaTime;
		}

	}
	public void Fill() {
		cooldown.fillAmount = 1f;
	}

	public void CallCooldown(float sec) {
		cooldownTime = sec;
		cooldown.fillAmount = 1f;
		isCoolingDown = true;
	}

	IEnumerator Cooldown(float sec) {
		float timeRemaining = sec;
		cooldown.fillAmount = 1f;
		while (timeRemaining > 0) {
			cooldown.fillAmount -= 1.0f / timeRemaining * Time.deltaTime;
			timeRemaining -= Time.deltaTime;
			yield return new WaitForSeconds(0.1f);
		}
		isCoolingDown = false;
		yield break;
	}

}
