using UnityEngine;
//using UnityEngine.UI;
using System.Collections;
using System;

public class SceneFade : MonoBehaviour
{
	[SerializeField]
	bool fadeInOnStart = false;

	[HideInInspector]
	public bool fading = false;

	private Renderer fadeRenderer;

	private Material fadeMaterial;

	
	void Start ()
	{
		fadeRenderer = GetComponent<Renderer>();
		fadeMaterial = fadeRenderer.material;
		FadeIn(Color.white, 1.0f);

		if (fadeInOnStart)
		{
			FadeIn(Color.black, 0.8f);
		}
	}

	public void FadeIn(Color startColor, float seconds)
	{
		StartCoroutine(Fade(startColor, Color.clear, seconds));
	}

	public void FadeOut(Color endColor, float seconds)
	{
		StartCoroutine(Fade(Color.clear, endColor, seconds));
	}

	public IEnumerator Fade(Color startColor, Color endColor, float seconds)
	{
		float startTime = Time.time;
		float endTime = startTime + seconds;

		while (Time.time < endTime)
		{
			float step = Mathf.InverseLerp(startTime, endTime, Time.time);
			fadeMaterial.color = Color.Lerp(startColor, endColor, step);
			yield return null;
		}

	}
	
}