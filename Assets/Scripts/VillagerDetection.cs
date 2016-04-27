using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using SecondDoorStudio.HotF.StateMachines;

public class VillagerDetection : MonoBehaviour {

	bool detecting = false;
	[SerializeField]
	float detectionRadius = 20f;

	[SerializeField]
	DetectorWisp wisp;

	List<DetectorWisp> spawnedWisps;
	PlayerBase playerBase;

	[SerializeField]
	float cooldown = 5f;
	float cooldownRemaining = 0f;

	[SerializeField]
	SpellIcon icon;

	[SerializeField]
	SpellCastEffect effect;

	SpellCastEffect activeEffect;

	Action previousBehaviour;

	void Start () {
		playerBase = GetComponent<PlayerBase>();
		spawnedWisps = new List<DetectorWisp>();
	}

	void Update () {
		if (detecting) {
			if (playerBase.currentShape != Shapeshift.Human) {
				DestroyBeacons();
				if (activeEffect != null) activeEffect.CallEndEffects();
				detecting = false;
				playerBase.CurrentBehaviour = previousBehaviour;
			}
			if (Input.GetKeyUp(KeyCode.Space)) {
				DestroyBeacons();
				if (activeEffect != null) activeEffect.CallEndEffects();
				detecting = false;

				playerBase.CurrentBehaviour = previousBehaviour;
			}
		} else {
			if (cooldownRemaining == 0f) {
				if (playerBase.currentShape == Shapeshift.Human) {
					if (Input.GetKeyDown(KeyCode.Space)) {

						previousBehaviour = playerBase.CurrentBehaviour;
						playerBase.CurrentBehaviour = null;
						detecting = true;

						activeEffect = (SpellCastEffect) Instantiate(effect, transform.position, Quaternion.Euler(-90,0,0));

						activeEffect.CallStartEffects(2f);
						SpawnBeacons();
						icon.Fill();
					}
				}
			}
		}
	}

	void SpawnBeacons () {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius);
        int i = 0;
        while (i < colliders.Length) {
        	VillagerController villagerController = colliders[i].GetComponent<VillagerController>();
        	if (villagerController != null) {
				if (!villagerController.isInSanctuary && !villagerController.isFollowing) {
					DetectorWisp newWisp = (DetectorWisp) Instantiate(wisp, colliders[i].transform.position, transform.rotation);
					newWisp.Target = transform.position;
					spawnedWisps.Add(newWisp);

        		}
        	}
            i++;
        }
    }

    void DestroyBeacons() {
    	foreach (DetectorWisp wisp in spawnedWisps) {
    		if (wisp != null) { 
    			wisp.CallFadeOut();
    		}
    	}
    	spawnedWisps.Clear();
    	StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown() {
    	icon.CallCooldown(cooldown);
    	cooldownRemaining = cooldown;
    	while (cooldownRemaining > 0) {
    		cooldownRemaining -= Time.deltaTime;
    		yield return new WaitForEndOfFrame();
    	}
    	cooldownRemaining = 0f;
    	icon.isCoolingDown = false;
    	yield break;
    }

}
