using UnityEngine;

public class TextureSway : MonoBehaviour {

	Renderer render;

	[SerializeField]
	string mapName = "_DetailAlbedoMap";

	[SerializeField]
	float offsetX = 0.01f;
	[SerializeField]
	float offsetY = 0.01f;
	[SerializeField]
	float speedX = 0.9f;
	[SerializeField]
	float speedY = 0.9f;

	void Start()
	{
		render = GetComponent<Renderer>();
	}

	void Update()
	{
		float x = Mathf.Sin(Time.time * speedX) * offsetX;
		float y = Mathf.Sin(Time.time * speedY) * offsetY;
		
		render.material.SetTextureOffset(mapName, new Vector2(x, y));
		
	}

}
