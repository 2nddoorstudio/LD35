using UnityEngine;
using System.Collections;

public class TestBlendShapes : MonoBehaviour {

	SkinnedMeshRenderer renderer;
	public float blendSpeed = 1;
    float blendOne = 0f;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<SkinnedMeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (blendOne < 100f) {
        	renderer.SetBlendShapeWeight (0, blendOne);
       		blendOne += blendSpeed;
       	}
	}
}
