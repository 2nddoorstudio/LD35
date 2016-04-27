using UnityEngine;
using System.Collections;

public static class Globals {

	public const int GroundLayer = 8; 	// Layer number, deteremined in the editor, for layer masks
	public static LayerMask GroundLayerMask = 1 << GroundLayer;

}