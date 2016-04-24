using UnityEngine;

public class TextureScroll : MonoBehaviour {

	Renderer render;

	[SerializeField]
	string mapName = "_DetailAlbedoMap";

	[SerializeField]
	float speedX = 0.9f;
	[SerializeField]
	float speedY = 0.9f;

	float xOffset = 0.0f;
	float yOffset = 0.0f;

	void Start()
	{
		render = GetComponent<Renderer>();
	}

	void Update () 
	{

		xOffset += speedX;
		yOffset += speedY;

		render.material.SetTextureOffset(mapName, new Vector2(xOffset, yOffset));
	}
}
