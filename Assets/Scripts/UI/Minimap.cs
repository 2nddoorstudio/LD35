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

	int mapToggle = 1;
	Vector3 previousScale = Vector3.one;

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

		if (Input.GetKeyDown(KeyCode.Minus)) {
			if (mapPanel.localScale.x > 0.25f) {
				mapPanel.localScale *= 0.5f;
				previousScale = mapPanel.localScale;
			}
		}
		if (Input.GetKeyDown(KeyCode.Equals)) {
			if (mapPanel.localScale.x < 0.75f) {
				mapPanel.localScale *= 2f;
				previousScale = mapPanel.localScale;
			}
		}

		// 	Simple toggle on/off of (small, upper-left) minimap
		//	if (Input.GetKeyDown(KeyCode.M)) {
		//		mapPanel.gameObject.SetActive(!mapPanel.gameObject.activeInHierarchy);
		//		GetComponent<Image>().enabled = !GetComponent<Image>().enabled;
		//	}

		if (Input.GetKeyDown(KeyCode.M)) {

			mapToggle++;
			if (mapToggle > 2) mapToggle = 0;

			switch (mapToggle) {
				case 0:
					mapPanel.gameObject.SetActive(false);
					GetComponent<Image>().enabled = false;
					mapPanel.localScale = previousScale;
					break;
				case 1:
					mapPanel.gameObject.SetActive(true);
					GetComponent<Image>().enabled = true;
					transform.localScale = Vector3.one;
					// Anchor/pivot to upper left, and offset 10px from upper left corner
					GetComponent<RectTransform>().pivot = new Vector2(0,1);
					GetComponent<RectTransform>().anchorMin = new Vector2(0,1);
					GetComponent<RectTransform>().anchorMax = new Vector2(0,1);
					GetComponent<RectTransform>().anchoredPosition = new Vector2(10,-10);
					break;
				case 2:
					transform.localScale = new Vector3(2,2,2);
					previousScale = mapPanel.localScale;
					mapPanel.localScale = new Vector3(0.25f, 0.25f, 0.25f);
					// Center the map on the screen
					GetComponent<RectTransform>().pivot = new Vector2(0.5f,0.5f);
					GetComponent<RectTransform>().anchorMin = new Vector2(0.5f,0.5f);
					GetComponent<RectTransform>().anchorMax = new Vector2(0.5f,0.5f);
					GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
					break;
				break;
			}

		}


		if (mapPanel.gameObject.activeInHierarchy) {

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


			foreach (KeyValuePair<RectTransform, UnitBase> villager in villagers) {
				float villagerX = villager.Value.transform.position.x / 200f * 500f;
				float villagerY = villager.Value.transform.position.z / 200f * 500f;
				villager.Key.anchoredPosition3D = new Vector3(villagerX, villagerY, 0);
				villager.Key.transform.rotation = Quaternion.identity;			
			}

		}


	}
}
