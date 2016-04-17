using UnityEngine;
using System.Collections;

// base class for AI units -- entites that can move automatically
public class AIBase : UnitBase {

	public float f_AITimestamp;
	
	public enum AIState {
		Wander = 1,
		Attack = 2,
		Panic = 3,
		Follow = 4
	}

	public enum AIGroup {
		Villager = 1,
		Enemy = 2
	}

	private AIState en_previousAIState;
	public AIState en_currentAIState;
	public AIGroup en_currentAIGroup;

	public override void Start () {

		base.Start ();

		// default config for class vars
		f_AITimestamp = Time.time;

	}

	public override void Update() {
		base.Update ();
	}

	public override void UpdateLogic() {
		base.UpdateLogic ();
	}

	public override void Event_AIUpdate() {

		// Update AI "current phase" timestamp if needed
		if (en_previousAIState != en_currentAIState) {
			f_AITimestamp = Time.time + 0.4F;
			en_previousAIState = en_currentAIState;
		}
			
	}

	public virtual void WanderMode() {
		return;
	}

	public virtual void AttackMode() {
		return;
	}

	public virtual void PanicMode() {
		return;
	}

	public virtual void FollowMode() {
		return;
	}
}
