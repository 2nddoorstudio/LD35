using UnityEngine;
using System.Collections;

public class VillagerAI : AIBase {

	// Use this for initialization
	public override void Start () {

		base.Start ();

		en_currentAIGroup = AIGroup.Villager;
		en_currentAIState = AIState.Wander; 
	}

	public override void Update() {
		base.Update ();
	}
}
