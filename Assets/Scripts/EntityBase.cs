using UnityEngine;
using System.Collections;

public class EntityBase : MonoBehaviour {

	#region "Class Vars"

	// Health vars
	public float f_currentHealth;
	public float f_maxHealth;

	// engine bookeeping
	public string s_entityName;
	public bool b_paused;
	public GameObject obj_gameManager;

	#endregion

	#region "Func: Constructor & Engine"

	// Use this for initialization
	void Start () {
	
		f_maxHealth = 100F;
		f_currentHealth = f_maxHealth;

		s_entityName = "DEFAULT_ENTITY";
		b_paused = false;

		if (obj_gameManager == null) {
			obj_gameManager = (GameObject)GameObject.Find ("GameManager");
		}

		obj_gameManager.GetComponent<GameManager> ().Pause += new GameManager.GamePause (GameManager_Pause);

	}
	
	// Update is called once per frame
	void Update () {
	
		if (b_paused != true) {

			// Arbitrary logic implementable per-class
			UpdateLogic ();

		} else {

			// Do nothing, we are paused
			return;

		}
	}

	void GameManager_Pause(object sender, System.EventArgs e) {

		if (b_paused == true) {
			b_paused = false;
		} else {
			b_paused = true;
		}

	}

	// Dummy function for subclasses to override, provides actual update function
	public virtual void UpdateLogic() {
		return;
	}

	#endregion

	#region "Func: Combat"

	// subtracts health from target, checks for death
	public void TakeDamage(float damageValue) {

		f_currentHealth -= damageValue;

		if (f_currentHealth <= 0) {
			KillEntity ();
		}
	}

	// Removes entity from game (assumedly due to no health)
	public void KillEntity() {

		// flesh out for some cool death anims / particles
		GameObject.Destroy (transform.gameObject);

	}
		
	#endregion

}
