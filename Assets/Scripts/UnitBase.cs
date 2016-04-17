using UnityEngine;
using System.Collections;

// Unit base for classes that can move
public class UnitBase : EntityBase {

	#region "Class Vars"

	// movement vars
	public Vector3 v3_moveToLocation;
	public float f_movementSpeed;
	public bool b_isMoving;

	// Combat vars
	public bool b_canAttack;		// can this unit attack?
	public float f_attackDamage;		// health damage incurred by attack
	public float f_attackCooldown;		// cooldown between attacks
	public float f_attackRange;			// range within attacks are valid
	private float f_attackTimestamp;		// timestamp for the next valid time after cooldown is elapsed
	public GameObject obj_attackTarget;			// pointer of targeted unit

	#endregion

	#region "Func: Constructor & Engine"

	// Use this for initialization
	public override void Start () {

		base.Start ();

		// default config for class vars
		v3_moveToLocation = transform.position;
		b_isMoving = false;

		b_canAttack = false;
		f_attackDamage = 10F;
		f_attackCooldown = 1F;
		f_attackRange = 100F;
		f_attackTimestamp = Time.time;

	}

	public override void Update() {
		base.Update ();
	}
	
	// Update is called once per frame
	public override void UpdateLogic() {

		// Do all applicable event checks
		// Move unit if needed
		Event_MoveUnit ();

		// Attack with unit if needed
		if (b_canAttack == true) {

			// if we have a valid target, attempt to attack
			if (obj_attackTarget != null) {
				Event_AttackUnit ();
			}

		}

		// Placeholder for overridable AI instructions
		Event_AIUpdate();
	}

	#endregion

	#region "Func: Movement"

	// internal event to move unit to the designated coordinate; used for update
	private void Event_MoveUnit() {

		// check if moving is necessary
		if (transform.position != v3_moveToLocation) {
			transform.position = Vector3.Lerp (transform.position, v3_moveToLocation, f_movementSpeed * Time.deltaTime);
		} else {
			b_isMoving = false;
		}

	}

	// Set location to move to (for external use)
	public void MoveTo(Vector3 newLocation) {
		v3_moveToLocation = newLocation;
		b_isMoving = true;
	}

	#endregion

	#region "Func: Combat"

	// Set target for attacks
	public void SetTarget(GameObject newTarget) {

		obj_attackTarget = newTarget;

	}

	// Cancel attack targeting (set to null)
	public void CancelTarget() {

		obj_attackTarget = null;

	}

	// attack an opposing unit; used for update event
	// function based? trigger based?
	private void Event_AttackUnit() {

		// check if attack cooldown has elapsed. Don't attack if not
		if (f_attackTimestamp <= Time.time) {

			// are we in range of the target?
			if (Vector3.Distance (transform.position, obj_attackTarget.transform.position) <= f_attackRange) {

				// get health vars of target, this attack is happening
				UnitBase target = obj_attackTarget.GetComponent<UnitBase> ();

				// calculate if we need to drop this target due to killing it
				if ((target.f_currentHealth - f_attackDamage) <= 0) {
					CancelTarget ();
				}

				// attack target
				target.TakeDamage(f_attackDamage);

				// refresh cooldown timestamp
				f_attackTimestamp = (Time.time + f_attackCooldown);

			}
		}
	}

	#endregion

	#region "Func: AI"

	public virtual void Event_AIUpdate() {
		return;
	}

	#endregion
}
