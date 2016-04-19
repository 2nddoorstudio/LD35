using UnityEngine;
using System.Collections;

public class ExitGame : MonoBehaviour {

	[SerializeField]
	SceneLoader sceneLoader;

	[SerializeField]
	bool exitGame = false;
	//TODO: fix this

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (exitGame)
				Application.Quit();
			else
				sceneLoader.OnBack();
		}

	}
}
