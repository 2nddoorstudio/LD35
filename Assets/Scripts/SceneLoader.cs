using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	[SerializeField]
	SceneFade fadeObject;

	[SerializeField]
	float fadeDuration = 1.0f;

	[SerializeField]
	AudioSource audioFade;

	public void OnPlay()
	{
		StartCoroutine(ChangeScene("MainScene"));
	}

	public void OnCredits()
	{
		StartCoroutine(ChangeScene("CreditsScene"));
	}

	public void OnBack()
	{
		StartCoroutine(ChangeScene("TitleScene"));
	}

	IEnumerator ChangeScene(string scene)
	{
		float startTime = Time.time;
		float endTime = startTime + fadeDuration;

		if (fadeObject != null)
			fadeObject.FadeOut(Color.black, fadeDuration);

		while (Time.time < endTime)
		{
			if (audioFade != null)
				audioFade.volume = Mathf.InverseLerp(endTime, startTime, Time.time);
			
			yield return null;
		}

		SceneManager.LoadScene(scene);
	}
}
