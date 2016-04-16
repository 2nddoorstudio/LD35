using UnityEngine;
using System.Collections;

public class ShaderTest : MonoBehaviour {

	[SerializeField]
	Renderer render;
	//Material material;

	enum PlayerMode
	{
		Human,
		Stag,
		Bear
	}

	float sliderA = 0.0f;
	float sliderB = 0.0f;

	PlayerMode mode;

	bool isTransforming = false;

	// Use this for initialization
	void Start () {
		
		//material = render.material;
	}
	
	// Update is called once per frame
	void Update () {

		Material material = render.material;

		Debug.Log(material.name);

		if (Input.GetKeyDown(KeyCode.A))
		{
			mode = PlayerMode.Human;
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			mode = PlayerMode.Stag;
		}
		if (Input.GetKeyDown(KeyCode.D))
		{
			mode = PlayerMode.Bear;
		}

		float newSliderA = 0.0f;
		float newSliderB = 0.0f;

		switch (mode) 
		{
		case PlayerMode.Human:
			newSliderA = 0.0f;
			newSliderB = 0.0f;
			break;
		case PlayerMode.Stag:
			newSliderA = 1.0f;
			newSliderB = 0.0f;
			break;
		case PlayerMode.Bear:
			newSliderA = 1.0f;
			newSliderB = 1.0f;
			break;
		default:
			break;
		}

		if (!Mathf.Approximately(sliderA, newSliderA) || !Mathf.Approximately(sliderB, newSliderB))
		{
			Debug.Log(material.GetFloat("_TransitionA").ToString());

			sliderA = Mathf.Lerp(sliderA, newSliderA, 0.1f);
			sliderB = Mathf.Lerp(sliderB, newSliderB, 0.1f);

			material.SetFloat("_TransitionA", sliderA);
			material.SetFloat("_TransitionB", sliderB);
			
			Debug.Log(material.GetFloat("_TransitionA").ToString());

		}

		//StartCoroutine(Shapeshift());
	}

	/*IEnumerator Shapeshift()
	{
		
	}*/
}
