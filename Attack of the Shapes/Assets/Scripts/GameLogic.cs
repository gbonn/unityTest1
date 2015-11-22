/* This file contains basic game initialization logic.
 * It is attached to a top-level empty GameObject.
 */

using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {

	// This prefab contains the vertical border pieces.
	public GameObject borderPrefab;
	
	// Use this for initialization
	void Start () {
		// Create the vertical borders procedurally. This is probably better done through
		// the WYSIWIG editor, but I wanted to see how the Instantiate call worked...
		// The numbers here are all based on the size of the vertical border sprite.
		for (int numVertBorderElements = 0; numVertBorderElements < 4; numVertBorderElements++) {
			// TODO: This is a hack to make a blank space for the UI elements to sit.
			// Needs better UI...
			if (numVertBorderElements < 3) {
				Instantiate (borderPrefab, new Vector3 (-2, numVertBorderElements * 4, 0), Quaternion.identity);
			}
			Instantiate (borderPrefab, new Vector3 (12, numVertBorderElements * 4, 0), Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
