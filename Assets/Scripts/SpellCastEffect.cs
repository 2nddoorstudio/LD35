using UnityEngine;
using System.Collections;

public class SpellCastEffect : MonoBehaviour {

	[SerializeField]
	Projector projector;
	ParticleSystem particleSystem;

	void Awake () {
		particleSystem = GetComponent<ParticleSystem>();
		projector.material.color = new Color(0,1f,1f,0);	
	}

	public void CallStartEffects (float duration) {
		StartCoroutine(StartEffects(duration));
	}
	public void CallEndEffects () {
		StartCoroutine(EndEffects());
	}

	IEnumerator StartEffects (float duration) {
		float timer = 0;
		float alpha = projector.material.color.a;

		while (timer < duration) {
			projector.orthographicSize = Mathf.Lerp(0, 1.5f, timer/duration);
			projector.transform.RotateAround(projector.transform.position, Vector3.up, 45f * Time.deltaTime);
			projector.material.color = new Color(0,1f,1f, Mathf.Lerp(alpha, 0.25f, (timer / duration)));
			//particleSystem.emission.rate = new ParticleSystem.MinMaxCurve(0, Mathf.Lerp(0,100f,(timer/duration)));

			//particleSystem.shape.radius = Mathf.Lerp(0,1.5f,(timer/duration));
			var x = particleSystem.shape;
			x.radius = Mathf.Lerp(0,1.5f,(timer/duration));

			timer += Time.deltaTime;
	        yield return new WaitForEndOfFrame();
		}
		yield break;
	}

	IEnumerator EndEffects() {
		float timer = 0;
		float duration = 0.35f;
		float alpha = projector.material.color.a;
		float currentProjectorSize = projector.orthographicSize;

		while (timer < duration) {
			projector.orthographicSize = Mathf.Lerp(currentProjectorSize, 0, timer/duration);
			projector.transform.RotateAround(projector.transform.position, Vector3.up, 180f * Time.deltaTime);
			projector.material.color = new Color(0,1f,1f, Mathf.Lerp(alpha, 0f, (timer / duration)));
			particleSystem.Stop();
			timer += Time.deltaTime;
	        yield return new WaitForEndOfFrame();
		}
		Destroy(gameObject);
		yield break;
	}

}
