using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public Canvas pauseMenu;
	public bool pauseEnabled = false;
		//public const float PauseSpeed = 0.0000001f;

	void Start()
	{
		pauseMenu = pauseMenu.GetComponent<Canvas>();
		pauseMenu.enabled = false;
			//pauseEnabled = false;
			//Time.timeScale = 1;
			//AudioListener.volume = 1;
			//UnityEngine.Cursor.visible = false;
	}

	void Update()
	{

		//check if pause button (escape key) is pressed
		if (Input.GetKeyDown("escape"))
		{

			//check if game is already paused		
			if (pauseEnabled == true)
			{
				//unpause the game
				pauseEnabled = false;
				pauseMenu.enabled = false;
					//Time.timeScale = 1;
					//AudioListener.volume = 1;
					//UnityEngine.Cursor.visible = false;			
			}

			//else if game isn't paused, then pause it
			else if (pauseEnabled == false)
			{
				pauseEnabled = true;
				pauseMenu.enabled = true;
					//AudioListener.volume = 0;
					//Time.timeScale = PauseSpeed;
					//UnityEngine.Cursor.visible = true;
			}
		}
	}


	public void OnResumeButton()
	{
		//unpause the game

		pauseEnabled = false;
		pauseMenu.enabled = false;
		//Time.timeScale = 1;
		//AudioListener.volume = 1;
	}

	public void OnStartButton()
	{
		SceneManager.LoadScene("MainScene");
	}

	public void OnCreditsButton()
	{
		SceneManager.LoadScene("Credits");
	}

	public void OnBackButton()
	{
		SceneManager.LoadScene("MenuScene");
	}

	public void OnExitButton()
	{
		Application.Quit();
	}

	//Reloads the Level
	public void OnReloadButton(){
		Application.LoadLevel(Application.loadedLevel);
	}

	//loads level by input
	public void LoadLevel(string level){
		Application.LoadLevel(level);
	}
}
