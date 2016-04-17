using UnityEngine;
using System.Collections;

// Base class for player; can transform, attack
public class PlayerBase : UnitBase {

	#region "Class Vars"

	// transformation vars
	public enum Shapeshift {
		Human = 1,
		Bear = 2,
		Stag = 3
	}

	public Shapeshift en_currentShape;

	#endregion

	// Use this for initialization
	public override void Start () {

		base.Start ();

		en_currentShape = Shapeshift.Human;
	}
	
	// Update is called once per frame
	public override void Update() {
		base.Update ();
	}
}
