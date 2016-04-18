using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EntityManager : MonoBehaviour {

	[SerializeField]
	float areaWidth = 200.0f;
	[SerializeField]
	float areaHeight = 200.0f;
	[SerializeField]
	float excludeZone = 25.0f;
	[SerializeField]
	GameObject villagerPrefab;
	[SerializeField]
	int villagerNumber = 40;
	[SerializeField]
	GameObject enemyPrefab;
	[SerializeField]
	int enemyNumber = 10;
	[SerializeField]
	List<GameObject> terrainPrefabs = new List<GameObject>();
	[SerializeField]
	List<int> terrainCount = new List<int>();

	List<UnitBase> villagers;
	List<UnitBase> enemies;
	List<GameObject> terrains;

	float widthMin;
	float widthMax;
	float heightMin;
	float heightMax;

	// Use this for initialization
	void Start () 
	{
		widthMin = -(areaWidth / 2);
		widthMax = widthMin + areaWidth;

		heightMin = -(areaHeight / 2);
		heightMax = heightMin + areaHeight;

		villagers = new List<UnitBase>();
		enemies = new List<UnitBase>();
		terrains = new List<GameObject>();

		for (int i = 0; i < villagerNumber; i++)
		{
			GameObject go = Instantiate(villagerPrefab);
			go.transform.position = GetRandomPosition(0.5f);
			villagers.Add(go.GetComponent<UnitBase>());

		}

		for (int i = 0; i < enemyNumber; i++)
		{
			GameObject go = Instantiate(enemyPrefab);
			go.transform.position = GetRandomPosition(0.0f);
			enemies.Add(go.GetComponent<UnitBase>());
		}

		for (int j = 0; j < terrainPrefabs.Count; j++)
		{
			for (int i = 0; i < terrainCount[j]; i++)
			{
				GameObject go = Instantiate(terrainPrefabs[j]);
				go.transform.position = GetRandomPosition(0.0f);
				terrains.Add(go);
			}
			
		}

	}

	Vector3 GetRandomPosition(float height)
	{
		Vector3 newPos;
		do
		{
			newPos = new Vector3(Random.Range(widthMin, widthMax), height, Random.Range(heightMin, heightMax));
		}
		while (newPos.x < excludeZone && newPos.x > -excludeZone && newPos.y < excludeZone && newPos.y > -excludeZone);
		
		return newPos;
	}

}
