using UnityEngine;
using System.Collections;

public class TextureScroll : MonoBehaviour {

	[SerializeField]
	Renderer render;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*Vector2 offset = render.material.GetTextureOffset("_DetailAlbedoMap");
		offset.x += 1f;
		render.material.SetTextureOffset("_DetailAlbedoMap", offset);*/
	}
}
