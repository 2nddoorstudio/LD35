using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour {
	private GameObject GameUI;
	public float currentHealth = 1f;
	public SpriteRenderer HealthUI;
	public GameObject CircleHuman;
	public Light HumanLight;
	public GameObject CircleStag;
	public Light StagLight;
	public GameObject CircleBear;
	public Light BearLight;


	CanvasRotation canvasRotation;

	// Use this for initialization
	void Start () {
		GameUI = GameObject.FindGameObjectWithTag("InGameUI");
		canvasRotation = GetComponent<CanvasRotation>();
		HumanLight.intensity = 0.75f;
		}

	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.A))
		{
			canvasRotation.RotateUI(GameUI, 240f, 0.3f);
			HumanLight.intensity = 0.75f;
			StagLight.intensity = 0f;
			BearLight.intensity = 0f;
		}

		if (Input.GetKeyDown(KeyCode.S))
		{
			canvasRotation.RotateUI(GameUI, 0f, 0.3f);
			StagLight.intensity = 0.75f;
			BearLight.intensity = 0f;
			HumanLight.intensity = 0f;
		}
		if (Input.GetKeyDown(KeyCode.D))
		{
			canvasRotation.RotateUI(GameUI, 120f, 0.3f);
			BearLight.intensity = 0.75f;
			HumanLight.intensity = 0f;
			StagLight.intensity = 0f;
		}

		HandleHealth ();


		//just for testing - remove from production
		//if (Input.GetKeyDown(KeyCode.X))
		//{
		//	currentHealth += -0.1f;
		//}

	}

	private void HandleHealth () {

		//update currenthealth here

		//use currenthealth to update colors
		HealthUI.color = Color.Lerp(Color.red,Color.green,currentHealth);

	}

}
