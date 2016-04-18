using UnityEngine;
using System.Collections;

public class PauseManager : MonoBehaviour {
	private GameObject PauseMenuRingLeft;
	private GameObject PauseMenuRingRight;
	//public SpriteRenderer InsideRing;
	CanvasRotation canvasRotationR;
	CanvasRotation canvasRotationL;
	private float alpha = 0.0f;

	public Canvas pauseMenu;
	public bool pauseEnabled = false;
	public const float PauseSpeed = 0.0f;

	void Start()
	{
		pauseMenu = pauseMenu.GetComponent<Canvas>();
		pauseMenu.enabled = false;
		pauseEnabled = false;
		Time.timeScale = 1;
		AudioListener.volume = 1;
		UnityEngine.Cursor.visible = false;

		PauseMenuRingRight = GameObject.FindGameObjectWithTag("PauseMenuRingRight");
		PauseMenuRingLeft = GameObject.FindGameObjectWithTag("PauseMenuRingLeft");
		canvasRotationR = PauseMenuRingRight.GetComponent<CanvasRotation>();
		canvasRotationL = PauseMenuRingLeft.GetComponent<CanvasRotation>();
		canvasRotationR.RotateUI(PauseMenuRingRight, 270f, 0.3f);
		canvasRotationL.RotateUI(PauseMenuRingLeft, 90f, 0.3f);
	}

	void Update()
	{

		//check if pause button (escape key) is pressed
		if (Input.GetKeyDown("escape"))
		{

			//check if game is already paused		
			if (pauseEnabled == true)
			{

				//pause menu UI
				canvasRotationR.RotateUI(PauseMenuRingRight, 270f, 0.3f);
				canvasRotationL.RotateUI(PauseMenuRingLeft, 90f, 0.3f);
				//alpha = Mathf.Lerp(0.0, 0.0, 0.3) ;
				//InsideRing.color = Color.Lerp(Color(0f,0f,0f, 0f),Color(0f,0f,0f, 0f),0.3f);

				//unpause the game
				pauseEnabled = false;
				pauseMenu.enabled = false;
				Time.timeScale = 1;
				AudioListener.volume = 1;
				UnityEngine.Cursor.visible = false;
			}

			//else if game isn't paused, then pause it
			else if (pauseEnabled == false)
			{

				//pause menu UI
				canvasRotationR.RotateUI(PauseMenuRingRight, 0f, 0.3f);
				canvasRotationL.RotateUI(PauseMenuRingLeft, 0f, 0.3f);
				//alpha = Mathf.Lerp(0.0, 0.8, 0.3) ;
				//InsideRing.color = Color.Lerp(Color(0f,0f,0f, 0f),Color(0f,0f,0f, 0f),0.3f);

				//pause the game
				pauseEnabled = true;
				pauseMenu.enabled = true;
				AudioListener.volume = 0;
				//Time.timeScale = PauseSpeed;
				UnityEngine.Cursor.visible = true;

			}
		}
	}


	public void OnResumeButton()
	{
		//pause menu UI
		canvasRotationR.RotateUI(PauseMenuRingRight, 270f, 0.3f);
		canvasRotationL.RotateUI(PauseMenuRingLeft, 90f, 0.3f);
		//InsideRing.color.a = 0f;

		//unpause the game
		pauseEnabled = false;
		pauseMenu.enabled = false;
		Time.timeScale = 1;
		AudioListener.volume = 1;
	}

//	public void InsideAlpha()
//	{
//		float lerp = Mathf.PingPong (Time.time, duration) / duration;
//
//		alpha = Mathf.Lerp(0.0, 1.0, lerp) ;
//		InsideRing.color.a = alpha;
//
//	}
}
