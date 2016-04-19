using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PressKeyToStart : MonoBehaviour {

	[SerializeField]
	SceneFade fadeObject;

	[SerializeField]
	float fadeDuration = 1.0f;

	[SerializeField]
	AudioSource audioFade;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown)
		{
			StartCoroutine(ChangeScene());
		}
	}

	IEnumerator ChangeScene()
	{
		float startTime = Time.time;
		float endTime = startTime + fadeDuration;

		fadeObject.FadeOut(Color.black, fadeDuration);

		while (Time.time < endTime)
		{
			audioFade.volume = Mathf.InverseLerp(endTime, startTime, Time.time);
			yield return null;
		}

		SceneManager.LoadScene("MainScene");
	}
}
