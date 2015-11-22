/*
 * This file contains the logic to coordinate the behavior of the
 * falling shapes. It is attached to each shape prefab, so it is
 * runnable on every shape generated. This has performance
 * implications as many shapes can be in play at once.
 * 
 */

using UnityEngine;
using System.Collections;

public class FallingShapeLogic : MonoBehaviour {

	// Track the currently selected shape. The OnMouseDown()
	// logic should make sure only one shape can appear
	// selected at one time.
	//
	// This is static across all shape objects so they can
	// each adjudicate the select/match/destroy process
	// individually.
	//
	// TODO: In a larger program, we'd probably want the
	// option for a more centralized game logic processor
	// to account for game modes and logging. Some research
	// into Unity architectures would be warranted.
	//
	// We'll use null as the sentinel value to indicate no
	// shape is currently selected.
	private static GameObject selectedShape = null;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// This function responds to mouse clicks on the shapes. It is
	// responsible for selecting and deselecting shapes (i.e. turn
	// the halo on/off), as well as destroying matched shapes.
	void OnMouseDown()
	{
		// Get a reference to the halo Behavior for this shape.
		// We'll need this reference to turn the halo on/off as part of
		// the shape selection indication.
		Behaviour haloBehaviour = gameObject.GetComponent ("Halo") as Behaviour;

		// If no shape is currently selected, enable this shape's halo and
		// set it as the selected shape.
		if (selectedShape == null) {
			haloBehaviour.enabled = true;
			selectedShape = gameObject;
		// If the user clicked on the already selected shape, disable the
		// selection by turning off the halo and setting the selected shape
		// to null.
		} else if (selectedShape == gameObject) {
			haloBehaviour.enabled = false;
			selectedShape = null;
		// If the user clicked a different shape, check to see if it matches
		// the color and shape of the selected shape.
		// If it does match, destroy both the selected shape and this one, and
		// reset the selected shape to null.
		} else if (DoShapesMatch(selectedShape, gameObject)){
			Destroy(selectedShape);
			selectedShape = null;
			Destroy(gameObject);
		}
	}

	// This function determines if two shapes match in color and shape type
	private bool DoShapesMatch(GameObject shape1, GameObject shape2) {
		bool doColorsMatch = 
			shape1.GetComponent<Renderer> ().material.GetColor ("_EmissionColor") == shape2.GetComponent<Renderer> ().material.GetColor ("_EmissionColor");
		bool doShapesMatch = shape1.name == shape2.name;

		return (doColorsMatch && doShapesMatch);
	}
}
