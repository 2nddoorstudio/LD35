using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour {
	[SerializeField]
	GameObject shapeshiftUI;
	CanvasRotation shapeshiftRotation;
	[SerializeField]
	GameObject waypointUI;
	CanvasRotation waypointRotation;

	[SerializeField]
	PlayerBase player;
	[SerializeField]
	GameObject grove;

	[SerializeField]
	Text scoreText;

	public float currentHealth = 1f;
	public SpriteRenderer HealthUI;
	public GameObject CircleHuman;
	public Light HumanLight;
	public GameObject CircleStag;
	public Light StagLight;
	public GameObject CircleBear;
	public Light BearLight;

	//[SerializeField]
	//CanvasRotation canvasRotation;

	// Use this for initialization
	void Start () 
	{
		//GameUI = GameObject.FindGameObjectWithTag("InGameUI");
		shapeshiftRotation = shapeshiftUI.GetComponent<CanvasRotation>();
		waypointRotation = waypointUI.GetComponent<CanvasRotation>();
		HumanLight.intensity = 0.75f;
	}

	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.A))
		{
			shapeshiftRotation.RotateUI(240f, 0.3f);
			HumanLight.intensity = 0.75f;
			StagLight.intensity = 0f;
			BearLight.intensity = 0f;
		}

		if (Input.GetKeyDown(KeyCode.S))
		{
			shapeshiftRotation.RotateUI(0f, 0.3f);
			StagLight.intensity = 0.75f;
			BearLight.intensity = 0f;
			HumanLight.intensity = 0f;
		}
		if (Input.GetKeyDown(KeyCode.D))
		{
			shapeshiftRotation.RotateUI(120f, 0.3f);
			BearLight.intensity = 0.75f;
			HumanLight.intensity = 0f;
			StagLight.intensity = 0f;
		}

		HandleHealth ();

		Vector2 v1 = Camera.main.WorldToViewportPoint(grove.transform.position.normalized);//new Vector2(grove.transform.position.x, grove.transform.position.z);//
		Vector2 v2 = Camera.main.WorldToViewportPoint(player.transform.position.normalized);//new Vector2(player.transform.position.x, player.transform.position.z);//player.transform.position;//


		float angle = Mathf.Atan2(v1.y - v2.y, v1.x - v2.x) * Mathf.Rad2Deg;
		waypointRotation.RotateUI(angle - 90.0f);

		scoreText.text = GameManager.safeVillagers.ToString();

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
