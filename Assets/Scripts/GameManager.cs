using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static int safeVillagers = 0;

	public bool b_gamePaused;

	public delegate void GamePause(object sender, System.EventArgs e);
	public event GamePause Pause;

	// Use this for initialization
	void Start () {

		b_gamePaused = false;

	}
	
	// Update is called once per frame
	void Update () {

		// check if we hit escape key
		if (Input.GetKey(KeyCode.Escape)) {
			
			if (b_gamePaused == true) {
				OnPause ();
				b_gamePaused = false;

			} else {
				OnPause ();
				b_gamePaused = true;

			}
		}
	}

	private void OnPause() {

		if (Pause != null) {
			Pause (this, System.EventArgs.Empty);
		}

	}
}
