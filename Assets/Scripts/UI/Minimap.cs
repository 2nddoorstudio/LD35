using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Minimap : MonoBehaviour {

	[SerializeField]
	GameObject player;

	[SerializeField]
	EntityManager entityManager;

	[SerializeField]
	RectTransform arrow;

	[SerializeField]
	GameObject minimapVillager;

	[SerializeField]
	RectTransform mapPanel;

	Dictionary<RectTransform, UnitBase> villagers;

	ScrollRect scroll;

	float mapWidth = 500f;	// map is 1000 units wide -- we need to divide this in half, to normalize to +/- 500

	[SerializeField]
	float overlap;		// this value is more "feel" than science -- adjust to suit.  tested value of 50 works fine as a default. 
						// we don't want the map to scroll smoothly to the boundary of 1 (max scroll) or we'll "overscroll" the map
						// instead, we want the scrolling to hit "1" right when our *field of view* first hits the edge
						// this lets the icon stay "glued" to the center until we see an edge, which visually reinforces the edge

	void Start () {
		scroll = GetComponent<ScrollRect>();
		villagers = new Dictionary<RectTransform, UnitBase>();

		foreach (UnitBase villager in entityManager.Villagers) {

			GameObject icon = (GameObject) Instantiate(minimapVillager) as GameObject;
//			icon.transform.localScale = Vector3.one;
			icon.transform.SetParent(mapPanel);
			icon.GetComponent<RectTransform>().localScale = Vector3.one;
//			icon.GetComponent<RectTransform>().rotation = Quaternion.Euler(Vector3.zero);
			villagers.Add(icon.GetComponent<RectTransform>(), villager);
		}
	}

	void Update () {

		// convert player's "world" x and z into the minimap's X/Y coordinates, -500 through 500.
		float playerX = player.transform.position.x / 200f * 500f;
		float playerY = player.transform.position.z / 200f * 500f;
		arrow.anchoredPosition = new Vector3(playerX, playerY, 0);

		float scrollOffset = (mapWidth / 2) + overlap;
		scroll.horizontalNormalizedPosition = (player.transform.position.x / scrollOffset + 0.5f);
		scroll.verticalNormalizedPosition = (player.transform.position.z / scrollOffset + 0.5f);


		Vector3 rotation = transform.rotation.eulerAngles;
		rotation.z = -player.transform.rotation.eulerAngles.y;
		arrow.transform.rotation = Quaternion.Euler(rotation);

//		foreach (RectTransform villager in villagers) {
//			float villagerX = player.transform.position.x / 200f * 500f;
//			float villagerY = player.transform.position.z / 200f * 500f;
//			arrow.anchoredPosition = new Vector2(playerX, playerY);
//		}

		foreach (KeyValuePair<RectTransform, UnitBase> villager in villagers) {
			float villagerX = villager.Value.transform.position.x / 200f * 500f;
			float villagerY = villager.Value.transform.position.z / 200f * 500f;
//			villager.Key.anchoredPosition = new Vector3(villagerX, villagerY, 0);
			villager.Key.anchoredPosition3D = new Vector3(villagerX, villagerY, 0);
			villager.Key.transform.rotation = Quaternion.identity;			
//Vector3 villagerRotation = new Vector3(0,0,0);
//			villager.Key.transform.rotation = Quaternion.Euler(villagerRotation);
//			villager.Key.anchoredPosition.;
//			villager.Key.transform.position = new Vector3(villagerX, villagerY, 0);

		}

	}
}
